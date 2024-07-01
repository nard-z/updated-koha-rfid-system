using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using System.IO.Ports;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using System.Management;
using WMPLib;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Media;
using System.Net.Http;
using System.Collections.Generic;
using System.Drawing;
using System.Timers;


//https://stackoverflow.com/questions/36076924/how-can-i-display-a-loading-control-while-a-process-is-waiting-for-be-finished
//https://stackoverflow.com/questions/10775367/cross-thread-operation-not-valid-control-textbox1-accessed-from-a-thread-othe
//https://www.youtube.com/watch?v=ivmRtpUo_fw

namespace RFID_Solutions
{
    public partial class Main : Form
    {
        //if serial is connected
        bool isConnected = false;
        //serial counter: used for overflow check limit of displayed serial reads
        int counter = 0;
        //serial com. port no.
        string comport = "";
        //data recieved from the serial com.
        string serialDataRecieved = "";
        //Serial Com. overhead of the string that is needed to be removed
        int overHeadLenght = 0;

        //if the program is fully active and running
        bool isActive = false;

        System.Windows.Forms.Timer refreshTimer;
        // Timer refreshTimer;
        readonly HttpClient client = new HttpClient();
        List<string> validEpcTags = new List<string>();

        //filereader for saving and encrypting file config.
        FileReaderWriter frw = new FileReaderWriter();

        //Alarm Setups
        string selectedAlarm = "";
        bool audioPlayerIsPlaying = false;
        WindowsMediaPlayer audioPlayer = new WindowsMediaPlayer();

        delegate void SetTextCallback(string text);
        delegate void GetTextCallback(string text);


        public Main()
        {
            InitializeComponent();
            InitializeComponentStatus();
            usbBackgroundWorker.RunWorkerAsync();
            InitializeTimer();
        }
        private void InitializeComponentStatus()
        {
            //populate saved settings here:
            //disable all buttons as necessary
            PrepAlarmFiles();
            ReadConfigToFile();
            //temp
            comboBox_removeExtra.SelectedIndex = 0;

        }
        //ALARM SETUPS
        private void PrepAlarmFiles()
        {
            string temp;
            try
            {
                DirectoryInfo di = new DirectoryInfo(Application.StartupPath + @"\Alarms");
                FileInfo[] files = di.GetFiles("*.mp3");
                //string str = "";
                foreach (FileInfo file in files)
                {
                    Console.WriteLine(file.Name);
                    temp = file.ToString();
                    comboBox_tones.Items.Add(temp.Substring(0, temp.Length - 4));
                }
                comboBox_tones.SelectedIndex = 0;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + "\n\nAdd the alarm tones on the specified location.", "Warning: Folder not found!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void button_testTones_Click(object sender, EventArgs e)
        {
            selectedAlarm = comboBox_tones.SelectedItem.ToString();
            if (!audioPlayerIsPlaying)
            {
                audioPlayer.URL = Application.StartupPath + @"\Alarms\" + selectedAlarm + ".mp3";
                audioPlayer.controls.play();
                button_testTones.Text = "Stop";
                comboBox_tones.Enabled = false;
                audioPlayerIsPlaying = true;
            }
            else
            {
                audioPlayer.controls.stop();
                button_testTones.Text = "Test Alarm";
                comboBox_tones.Enabled = true;
                audioPlayerIsPlaying = false;
            }
        }
        //ALARM SETUP ENDS
        private void usbBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.backgroundworker?view=net-5.0

            WqlEventQuery insertQuery = new WqlEventQuery("SELECT * FROM __InstanceCreationEvent WITHIN 2 WHERE TargetInstance ISA 'Win32_SerialPort'");

            ManagementEventWatcher insertWatcher = new ManagementEventWatcher(insertQuery);
            insertWatcher.EventArrived += new EventArrivedEventHandler(DeviceInsertedEvent);
            insertWatcher.Start();

            WqlEventQuery removeQuery = new WqlEventQuery("SELECT * FROM __InstanceDeletionEvent WITHIN 2 WHERE TargetInstance ISA 'Win32_SerialPort'");
            ManagementEventWatcher removeWatcher = new ManagementEventWatcher(removeQuery);
            removeWatcher.EventArrived += new EventArrivedEventHandler(DeviceRemovedEvent);
            removeWatcher.Start();

            // Do something while waiting for events
            System.Threading.Thread.Sleep(20000000);
        }

        private void DeviceInsertedEvent(object sender, EventArrivedEventArgs e)
        {
            //refresh list serial com
            FetchSerialCom();
        }
        private void DeviceRemovedEvent(object sender, EventArrivedEventArgs e)
        {
            ManagementBaseObject instance = (ManagementBaseObject)e.NewEvent["TargetInstance"];
            foreach (var property in instance.Properties)
            {
                //Console.WriteLine(property.Name + " = " + property.Value);
                if (property.Name == "DeviceID")
                {
                    //Console.WriteLine(property.Value);
                    if (property.Value.ToString() == comport)
                    {
                        ConnectSerial();
                    }
                    //refresh list of serialport
                    FetchSerialCom();
                }
            }
        }

        public void SetStrtBtnStatus()
        {
            if (isActive)
            {
                button_saveStart.Text = "Stop";
                WriteConfigToFile();
            }
            else
            {
                button_saveStart.Text = "Save and Start";
            }
            button_connect.Enabled = !isActive;
            groupBox_SerialConfig.Enabled = !isActive;
            groupBox_alarm.Enabled = !isActive;
            //migrate this on appropriate location.. test only
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Help help = new Help();
            help.ShowDialog();
        }

        private void volumeSlider_Scroll(object sender, EventArgs e)
        {
            volLabel.Text = slider_volume.Value.ToString();
            audioPlayer.settings.volume = slider_volume.Value;
        }
        public void FetchSerialCom()
        {
            try
            {

                if (this.InvokeRequired)
                {
                    MethodInvoker del = delegate { FetchSerialCom(); };
                    this.BeginInvoke(del);
                }
                else
                {
                    comboBox_serialPort.Items.Clear();

                    string[] ports = SerialPort.GetPortNames();

                    foreach (string port in ports)
                    {
                        if (!comboBox_serialPort.Items.Contains(port) || port != comport)
                        {
                            comboBox_serialPort.Items.Add(port);
                        }
                    }
                    comboBox_serialPort.SelectedIndex = 0;
                    comboBox_baudRate.SelectedItem = "9600";

                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Exception: " + e.Message);
            }

        }
        /// Serial
        public void ConnectSerial()
        {
            overHeadLenght = Int32.Parse(comboBox_removeExtra.Text);
            try
            {
                if (this.InvokeRequired)
                {
                    MethodInvoker del = delegate { ConnectSerial(); };
                    this.BeginInvoke(del);
                }

                if (isConnected == false)
                {
                    CallToConnect();
                }
                else
                {
                    CallToDisconnect();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message);
            }
        }
        private void CallToConnect()
        {
            serialPort_control.BaudRate = int.Parse(comboBox_baudRate.SelectedItem.ToString());
            serialPort_control.PortName = comboBox_serialPort.SelectedItem.ToString();
            serialPort_control.DtrEnable = true;

            comport = serialPort_control.PortName;
            try
            {
                serialPort_control.Open();
            }

            catch (Exception)
            {
                //MessageBox.Show(e.ToString());
                MessageBox.Show("The Serial port doesn't exist or is being used by other application", "Serial port error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (serialPort_control.IsOpen)
            {
                comboBox_baudRate.Enabled = false;
                comboBox_serialPort.Enabled = false;
                isConnected = true;
                //or disable the group
                button_connect.Text = "Disconnect";
                MessageBox.Show("The Serial port is now open", "Operation succeeded!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void CallToDisconnect()
        {
            comport = "";
            serialPort_control.DiscardOutBuffer();
            serialPort_control.Close();
            serialPort_control.Dispose();
            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
            isConnected = false;
            button_connect.Text = "Connect";
            comboBox_baudRate.Enabled = true;
            comboBox_serialPort.Enabled = true;
            //or enable the group
        }
        ///-------------
        private void SetText(string text)
        {
            Console.WriteLine("data fetch: ", text);

            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.richTextBox_serialReceived.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.BeginInvoke(d, new object[] { text });
            }
            else
            {
                this.richTextBox_serialReceived.AppendText(text + "\n");
                //this.richTextBox_serialReceived.ScrollToCaret();
            }
        }

        private async void serialPort_control_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                if (serialPort_control == null)
                {
                    Console.WriteLine("Serial port is not initialized.");
                    return;
                }

                string value = serialPort_control.ReadLine()?.Trim();

                if (string.IsNullOrEmpty(value))
                {
                    Console.WriteLine("Received an empty or null value from the serial port.");
                    return;
                }

                Console.WriteLine("Received raw value: " + value);

                if (counter < overHeadLenght)
                {
                    counter++;
                }
                else
                {
                    serialDataRecieved= "";
                    counter = 0;
                }

                value = value.Trim('', '');

                if (value.Length > overHeadLenght)
                {
                    string processedValue = value.Substring(overHeadLenght).TrimStart('0').Trim();

                    if (string.IsNullOrEmpty(processedValue))
                    {
                        Console.WriteLine("Processed value is empty or null after trimming.");
                        return;
                    }

                    serialDataRecieved = processedValue;

                    // Log the received tag for debugging
                    Console.WriteLine("Received EPC Tag: " + serialDataRecieved);

                    // Check if the tag without leading zeros exists in the list
                    string processedTag = serialDataRecieved.TrimStart('0').Trim();
                    Console.WriteLine("Processed Tag for Comparison: " + processedTag);
                    if (!validEpcTags.Contains(processedTag))
                    {
                        SetText("Tag is Invalid");
                        Console.WriteLine("Tag is Invalid: " + processedTag);
                        TriggerAlarm();
                    }
                    else
                    {
                        SetText("Tag is Valid");
                        Console.WriteLine("Tag is Valid: " + processedTag);
                        HighlightTagInTable(processedTag);
                    }

                    // Reset serialDataReceived after processing
                    serialDataRecieved = string.Empty;

                    SetText(serialDataRecieved.ToString());
                }
                else
                {
                    Console.WriteLine("Received data is shorter than the overhead length.");
                }
                serialPort_control.DiscardOutBuffer();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error processing serial data: " + ex.Message);
            }
        }
        private void HighlightTagInTable(string tag)
        {
            foreach (DataGridViewRow row in dataGridView_curCheckout.Rows)
            {
                if (row.Cells["Barcode"] != null && row.Cells["Barcode"].Value != null && row.Cells["Barcode"].Value.ToString() == tag)
                {
                    row.DefaultCellStyle.BackColor = Color.Green;
                    break;
                }
            }
        }
        private async void RefreshTimer_Tick(object sender, EventArgs e)
        {
            if (isActive)
            {
               await RefreshDataGridView();
            }
        }
        private async Task RefreshDataGridView()
        {
            string url = "http://" + textbox_serverip.Text + "/cgi-bin/koha/svc/report?id=" + textbox_Creportno.Text + "&annotated=1";
            Console.WriteLine(url);
            WebRequest request = HttpWebRequest.Create(url);

            try
            {
                WebResponse response = await request.GetResponseAsync();
                if (response != null)
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        var responseText = await reader.ReadToEndAsync();
                        Console.WriteLine("API Response: " + responseText);

                        var dt = ConvertJsonToDataTable(responseText);
                        dataGridView_curCheckout.DataSource = dt;

                        if (dataGridView_curCheckout.Columns.Contains("Barcode"))
                        {
                            dataGridView_curCheckout.Columns["Barcode"].DisplayIndex = 0;
                            dataGridView_curCheckout.Columns["Barcode"].Width = 65;
                        }
                        if (dataGridView_curCheckout.Columns.Contains("Title"))
                        {
                            dataGridView_curCheckout.Columns["Title"].Width = 500;
                        }

                        PopulateValidEpcTags(dt);
                    }
                }
                else
                {
                    Console.WriteLine("Response from API is null.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching data: " + ex.Message);
            }
        }
        private void InitializeTimer()
        {
            refreshTimer = new System.Windows.Forms.Timer();
            refreshTimer.Interval = 3000; // 3 seconds
            refreshTimer.Tick += RefreshTimer_Tick;
            refreshTimer.Start();
        }



        private void TriggerAlarm()
        {
            {
                {
                    // Play a sound to signal the alarm
                    try
                    {
                        // Replace with the path to your alarm sound file
                        string soundFilePath = @"C:\alarm.wav";
                        using (SoundPlayer player = new SoundPlayer(soundFilePath))
                        {
                            player.PlaySync(); // Play the sound synchronously
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error playing alarm sound: " + ex.Message);
                    }

                    // Optionally, you can add additional alarm actions, such as visual alerts
                    // MessageBox.Show("Alarm: RFID Tag not found!", "Alarm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                //throw new NotImplementedException();
            }
            //throw new NotImplementedException();
        }

        private async Task<bool> CompareDataFromTable(string rfidValue)
        {
            string url = "http://" + textbox_serverip.Text + "/cgi-bin/koha/svc/report?id=" + textbox_Creportno.Text + "&annotated=1";
            Console.WriteLine(url);
            WebRequest request = WebRequest.Create(url);
            request.Method = "GET";

            try
            {
                using (WebResponse response = await request.GetResponseAsync())
                {
                    if (response != null)
                    {
                        using (Stream dataStream = response.GetResponseStream())
                        {
                            using (StreamReader reader = new StreamReader(dataStream))
                            {
                                var responseText = await reader.ReadToEndAsync();
                                Console.WriteLine("API Response: " + responseText);

                                var dt = ConvertJsonToDataTable(responseText);
                                dataGridView_curCheckout.DataSource = dt;

                                if (dataGridView_curCheckout.Columns.Contains("Barcode"))
                                {
                                    dataGridView_curCheckout.Columns["Barcode"].DisplayIndex = 0;
                                    dataGridView_curCheckout.Columns["Barcode"].Width = 65;
                                }
                                if (dataGridView_curCheckout.Columns.Contains("Title"))
                                {
                                    dataGridView_curCheckout.Columns["Title"].Width = 500;
                                }

                                PopulateValidEpcTags(dt);
                                return validEpcTags.Contains(rfidValue);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Response from API is null.");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching data: " + ex.Message);
                return false;
            }
        }


        private void Main_Load(object sender, EventArgs e)
        {
            FetchSerialCom();
            
        }

        private async void button_saveStart_Click(object sender, EventArgs e)
        {
            if (isActive == false)
            {
                string url = "http://" + textbox_serverip.Text + "/cgi-bin/koha/svc/report?id=" + textbox_Creportno.Text + "&annotated=1";
                Console.WriteLine(url);
                WebRequest request = HttpWebRequest.Create(url);

                try
                {
                    WebResponse response = await request.GetResponseAsync();
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    var responseText = await reader.ReadToEndAsync();
                    Console.WriteLine("API Response: " + responseText);

                    var dt = ConvertJsonToDataTable(responseText);
                    dataGridView_curCheckout.DataSource = dt;

                    if (dataGridView_curCheckout.Columns.Contains("Barcode"))
                    {
                        dataGridView_curCheckout.Columns["Barcode"].DisplayIndex = 0;
                        dataGridView_curCheckout.Columns["Barcode"].Width = 65;
                    }
                    if (dataGridView_curCheckout.Columns.Contains("Title"))
                    {
                        dataGridView_curCheckout.Columns["Title"].Width = 500;
                    }

                    PopulateValidEpcTags(dt);
                    isActive = true;
                    SetStrtBtnStatus();
                    refreshTimer.Start(); // Start the timer
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error fetching data: " + ex.Message);
                }
            }
            else
            {
                isActive = false;
                SetStrtBtnStatus();
                refreshTimer.Stop(); // Stop the timer
            }
        }

        private void PopulateValidEpcTags(DataTable dataTable)
        {
            validEpcTags.Clear();
            foreach (DataRow row in dataTable.Rows)
            {
                if (row["Barcode"] != null)
                {
                    string barcode = row["Barcode"].ToString().TrimStart('0').Trim(); // Remove leading zeros and trim spaces
                    validEpcTags.Add(barcode);
                }
                else
                {
                    Console.WriteLine("Barcode field is null in one of the rows.");
                }
            }

            // Log the populated tags for debugging
            Console.WriteLine("Valid EPC Tags:");
            foreach (var tag in validEpcTags)
            {
                Console.WriteLine("Valid Tag: " + tag);
            }
        }
        //--saving configurations on a file
        private bool WriteConfigToFile()
        {
            String serialPort, baudRate, serverIP, extras, cReportNo, tReportNo, alarmTone, volume, volumeRepeated;
            bool result;
            serialPort = comboBox_serialPort.SelectedItem.ToString();
            baudRate = comboBox_baudRate.SelectedItem.ToString();
            serverIP = textbox_serverip.Text;
            extras = comboBox_removeExtra.SelectedItem.ToString();
            cReportNo =  textbox_Creportno.Text;
            tReportNo = textBox_TreportNo.Text;
            alarmTone = comboBox_tones.SelectedItem.ToString();
            volume = slider_volume.Value.ToString();
            volumeRepeated = checkBox_volumeRepeated.Checked.ToString();
            result = frw.WriteConfigFile(serialPort, baudRate, serverIP, extras, cReportNo, tReportNo, alarmTone, volume, volumeRepeated);
            if (result)
            {
                MessageBox.Show("Configuration Saved Successfully.", "Success!");
                //button_revert.Enabled = true;
            }
            else
            {
                MessageBox.Show("Error in Saving the Configuration File.", "Error!");
            }
            return result;
        }
        private void ReadConfigToFile()
        {

            string[] configArray;// = new string[];
            configArray = frw.ReadConfigFile();
            foreach (string config in configArray)
            {
                Console.WriteLine(config);
            }
        }

            private void ReadConfigToFile1()
        {

            string[] configArray;// = new string[];
            configArray = frw.ReadConfigFile();
            comboBox_serialPort.SelectedItem = configArray[0];
            comboBox_baudRate.SelectedItem = configArray[1];
            textbox_serverip.Text = configArray[2];
            comboBox_removeExtra.SelectedItem = configArray[3];
            textbox_Creportno.Text = configArray[4];
            textBox_TreportNo.Text = configArray[5];
            comboBox_tones.SelectedItem = configArray[6];
            bool successIntTryParse = int.TryParse(configArray[7], out int number);
            if (successIntTryParse)
            {
                slider_volume.Value = number;
            }
            else
            {
                Console.WriteLine($"Attempted conversion of '{configArray[7] ?? "<null>"}' failed.");
            }
            bool successBoolTryParse = Boolean.TryParse(configArray[8], out bool output);
            if (successBoolTryParse)
            {
                checkBox_volumeRepeated.Checked = output;
            }
            else
            {
                Console.WriteLine($"Attempted conversion of '{configArray[8] ?? "<null>"}' failed.");
            }
        }

        private static string AddSquareBrackets(string json)
        {
            return $"[{json}]";
        }
        private static DataTable ConvertJsonToDataTable(string jsonData)
        {
            try
            {
                return JsonConvert.DeserializeObject<DataTable>(jsonData);
            }
            catch
            {
                return null;
            }
        }

        private void textbox_serverip_Leave(object sender, EventArgs e)
        {
            Match match = Regex.Match(textbox_serverip.Text, @"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}");
            if (!match.Success)
            {
                label_invalidIP.Visible = true;
                //flag 2.1 false
            }
            else
            {
                //flag 2.1 true
            }
        }

        private void textbox_reportno_Leave(object sender, EventArgs e)
        {
            Match match = Regex.Match(textbox_Creportno.Text, @"^[1-9]\d*$");
            if (!match.Success)
            {
                label_invalidReport.Visible = true;
                //flag 2.2 false
            }
            else
            {
                //flag 2.2 true
            }
        }

        private void textbox_serverip_Enter(object sender, EventArgs e)
        {
            label_invalidIP.Visible = false;
        }

        private void textbox_reportno_Enter(object sender, EventArgs e)
        {
            label_invalidReport.Visible = false;
        }

        private void dataGridView_curCheckout_MouseHover(object sender, EventArgs e)
        {
            dataGridView_curCheckout.ScrollBars = ScrollBars.Both;
        }

        private void dataGridView_curCheckout_MouseLeave(object sender, EventArgs e)
        {
            dataGridView_curCheckout.ScrollBars = ScrollBars.None;
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult exit = MessageBox.Show("Do you really want to close this application?", "Exiting?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (exit == DialogResult.Yes)
            {
                //if open serial com open close
                if (serialPort_control.IsOpen == true)
                {
                    serialPort_control.Close();
                }
                //close program
                e.Cancel = false;
            }
            else
            {
                //cancel closing
                e.Cancel = true;
            }
        }

        private void button_connect_Click(object sender, EventArgs e)
        {
            ConnectSerial();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
