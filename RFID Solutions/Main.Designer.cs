namespace RFID_Solutions
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox_SerialConfig = new System.Windows.Forms.GroupBox();
            this.comboBox_removeExtra = new System.Windows.Forms.ComboBox();
            this.label_removeExtra = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_TreportNo = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label_invalidReport = new System.Windows.Forms.Label();
            this.label_invalidIP = new System.Windows.Forms.Label();
            this.button_help = new System.Windows.Forms.Button();
            this.comboBox_baudRate = new System.Windows.Forms.ComboBox();
            this.textbox_Creportno = new System.Windows.Forms.TextBox();
            this.label_baudRate = new System.Windows.Forms.Label();
            this.textbox_serverip = new System.Windows.Forms.TextBox();
            this.comboBox_serialPort = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label_serialPort = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button_saveStart = new System.Windows.Forms.Button();
            this.groupBox_alarm = new System.Windows.Forms.GroupBox();
            this.checkBox_volumeRepeated = new System.Windows.Forms.CheckBox();
            this.volLabel = new System.Windows.Forms.Label();
            this.slider_volume = new System.Windows.Forms.TrackBar();
            this.button_testTones = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_tones = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button_connect = new System.Windows.Forms.Button();
            this.serialPort_control = new System.IO.Ports.SerialPort(this.components);
            this.dataGridView_curCheckout = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.usbBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.richTextBox_serialReceived = new System.Windows.Forms.RichTextBox();
            this.groupBox2.SuspendLayout();
            this.groupBox_SerialConfig.SuspendLayout();
            this.groupBox_alarm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.slider_volume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_curCheckout)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(318, 407);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(622, 137);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Warning Details:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(15, 24);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(591, 71);
            this.textBox1.TabIndex = 23;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(413, 101);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(109, 26);
            this.button3.TabIndex = 22;
            this.button3.Text = "Show Details";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(528, 101);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(78, 26);
            this.button2.TabIndex = 21;
            this.button2.Text = "Clear";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // groupBox_SerialConfig
            // 
            this.groupBox_SerialConfig.Controls.Add(this.comboBox_removeExtra);
            this.groupBox_SerialConfig.Controls.Add(this.label_removeExtra);
            this.groupBox_SerialConfig.Controls.Add(this.label8);
            this.groupBox_SerialConfig.Controls.Add(this.label9);
            this.groupBox_SerialConfig.Controls.Add(this.textBox_TreportNo);
            this.groupBox_SerialConfig.Controls.Add(this.label10);
            this.groupBox_SerialConfig.Controls.Add(this.label7);
            this.groupBox_SerialConfig.Controls.Add(this.label_invalidReport);
            this.groupBox_SerialConfig.Controls.Add(this.label_invalidIP);
            this.groupBox_SerialConfig.Controls.Add(this.button_help);
            this.groupBox_SerialConfig.Controls.Add(this.comboBox_baudRate);
            this.groupBox_SerialConfig.Controls.Add(this.textbox_Creportno);
            this.groupBox_SerialConfig.Controls.Add(this.label_baudRate);
            this.groupBox_SerialConfig.Controls.Add(this.textbox_serverip);
            this.groupBox_SerialConfig.Controls.Add(this.comboBox_serialPort);
            this.groupBox_SerialConfig.Controls.Add(this.label1);
            this.groupBox_SerialConfig.Controls.Add(this.label_serialPort);
            this.groupBox_SerialConfig.Controls.Add(this.label2);
            this.groupBox_SerialConfig.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_SerialConfig.Location = new System.Drawing.Point(12, 12);
            this.groupBox_SerialConfig.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox_SerialConfig.Name = "groupBox_SerialConfig";
            this.groupBox_SerialConfig.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox_SerialConfig.Size = new System.Drawing.Size(299, 315);
            this.groupBox_SerialConfig.TabIndex = 22;
            this.groupBox_SerialConfig.TabStop = false;
            this.groupBox_SerialConfig.Text = "Configurations:  ";
            // 
            // comboBox_removeExtra
            // 
            this.comboBox_removeExtra.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.comboBox_removeExtra.BackColor = System.Drawing.SystemColors.Window;
            this.comboBox_removeExtra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_removeExtra.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBox_removeExtra.ForeColor = System.Drawing.SystemColors.WindowText;
            this.comboBox_removeExtra.FormattingEnabled = true;
            this.comboBox_removeExtra.ItemHeight = 18;
            this.comboBox_removeExtra.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.comboBox_removeExtra.Location = new System.Drawing.Point(109, 119);
            this.comboBox_removeExtra.MaxDropDownItems = 5;
            this.comboBox_removeExtra.Name = "comboBox_removeExtra";
            this.comboBox_removeExtra.Size = new System.Drawing.Size(130, 26);
            this.comboBox_removeExtra.TabIndex = 29;
            // 
            // label_removeExtra
            // 
            this.label_removeExtra.AutoSize = true;
            this.label_removeExtra.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_removeExtra.Location = new System.Drawing.Point(6, 121);
            this.label_removeExtra.Name = "label_removeExtra";
            this.label_removeExtra.Size = new System.Drawing.Size(95, 16);
            this.label_removeExtra.TabIndex = 30;
            this.label_removeExtra.Text = "Remove Extra:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(8, 220);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 16);
            this.label8.TabIndex = 28;
            this.label8.Text = "Report No.:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(163, 220);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 16);
            this.label9.TabIndex = 27;
            this.label9.Text = "Invalid";
            this.label9.Visible = false;
            // 
            // textBox_TreportNo
            // 
            this.textBox_TreportNo.Location = new System.Drawing.Point(96, 218);
            this.textBox_TreportNo.Name = "textBox_TreportNo";
            this.textBox_TreportNo.Size = new System.Drawing.Size(64, 24);
            this.textBox_TreportNo.TabIndex = 26;
            this.textBox_TreportNo.Text = "61";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 196);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(108, 16);
            this.label10.TabIndex = 25;
            this.label10.Text = "Compare Tag to:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(8, 174);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 16);
            this.label7.TabIndex = 24;
            this.label7.Text = "Report No.:";
            // 
            // label_invalidReport
            // 
            this.label_invalidReport.AutoSize = true;
            this.label_invalidReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_invalidReport.ForeColor = System.Drawing.Color.Red;
            this.label_invalidReport.Location = new System.Drawing.Point(163, 174);
            this.label_invalidReport.Name = "label_invalidReport";
            this.label_invalidReport.Size = new System.Drawing.Size(46, 16);
            this.label_invalidReport.TabIndex = 23;
            this.label_invalidReport.Text = "Invalid";
            this.label_invalidReport.Visible = false;
            // 
            // label_invalidIP
            // 
            this.label_invalidIP.AutoSize = true;
            this.label_invalidIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_invalidIP.ForeColor = System.Drawing.Color.Red;
            this.label_invalidIP.Location = new System.Drawing.Point(242, 91);
            this.label_invalidIP.Name = "label_invalidIP";
            this.label_invalidIP.Size = new System.Drawing.Size(46, 16);
            this.label_invalidIP.TabIndex = 22;
            this.label_invalidIP.Text = "Invalid";
            this.label_invalidIP.Visible = false;
            // 
            // button_help
            // 
            this.button_help.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_help.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_help.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button_help.Image = global::RFID_Solutions.Properties.Resources.help1;
            this.button_help.Location = new System.Drawing.Point(261, 13);
            this.button_help.Name = "button_help";
            this.button_help.Size = new System.Drawing.Size(32, 32);
            this.button_help.TabIndex = 20;
            this.button_help.UseVisualStyleBackColor = true;
            this.button_help.Click += new System.EventHandler(this.button5_Click);
            // 
            // comboBox_baudRate
            // 
            this.comboBox_baudRate.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.comboBox_baudRate.BackColor = System.Drawing.SystemColors.Window;
            this.comboBox_baudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_baudRate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBox_baudRate.ForeColor = System.Drawing.SystemColors.WindowText;
            this.comboBox_baudRate.FormattingEnabled = true;
            this.comboBox_baudRate.ItemHeight = 18;
            this.comboBox_baudRate.Items.AddRange(new object[] {
            "300",
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "74880",
            "115200",
            "230400",
            "250000"});
            this.comboBox_baudRate.Location = new System.Drawing.Point(109, 56);
            this.comboBox_baudRate.MaxDropDownItems = 5;
            this.comboBox_baudRate.Name = "comboBox_baudRate";
            this.comboBox_baudRate.Size = new System.Drawing.Size(130, 26);
            this.comboBox_baudRate.TabIndex = 2;
            // 
            // textbox_Creportno
            // 
            this.textbox_Creportno.Location = new System.Drawing.Point(96, 172);
            this.textbox_Creportno.Name = "textbox_Creportno";
            this.textbox_Creportno.Size = new System.Drawing.Size(64, 24);
            this.textbox_Creportno.TabIndex = 19;
            this.textbox_Creportno.Text = "61";
            this.textbox_Creportno.Enter += new System.EventHandler(this.textbox_reportno_Enter);
            this.textbox_Creportno.Leave += new System.EventHandler(this.textbox_reportno_Leave);
            // 
            // label_baudRate
            // 
            this.label_baudRate.AutoSize = true;
            this.label_baudRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_baudRate.Location = new System.Drawing.Point(6, 58);
            this.label_baudRate.Name = "label_baudRate";
            this.label_baudRate.Size = new System.Drawing.Size(77, 16);
            this.label_baudRate.TabIndex = 17;
            this.label_baudRate.Text = "Baud Rate: ";
            // 
            // textbox_serverip
            // 
            this.textbox_serverip.Location = new System.Drawing.Point(109, 89);
            this.textbox_serverip.Name = "textbox_serverip";
            this.textbox_serverip.Size = new System.Drawing.Size(130, 24);
            this.textbox_serverip.TabIndex = 18;
            this.textbox_serverip.Text = "192.168.40.2";
            this.textbox_serverip.Enter += new System.EventHandler(this.textbox_serverip_Enter);
            this.textbox_serverip.Leave += new System.EventHandler(this.textbox_serverip_Leave);
            // 
            // comboBox_serialPort
            // 
            this.comboBox_serialPort.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.comboBox_serialPort.BackColor = System.Drawing.SystemColors.Window;
            this.comboBox_serialPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_serialPort.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBox_serialPort.ForeColor = System.Drawing.SystemColors.WindowText;
            this.comboBox_serialPort.FormattingEnabled = true;
            this.comboBox_serialPort.ItemHeight = 18;
            this.comboBox_serialPort.Location = new System.Drawing.Point(109, 24);
            this.comboBox_serialPort.MaxDropDownItems = 5;
            this.comboBox_serialPort.Name = "comboBox_serialPort";
            this.comboBox_serialPort.Size = new System.Drawing.Size(130, 26);
            this.comboBox_serialPort.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 16);
            this.label1.TabIndex = 17;
            this.label1.Text = "Currently Checked Out Materials:";
            // 
            // label_serialPort
            // 
            this.label_serialPort.AutoSize = true;
            this.label_serialPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_serialPort.Location = new System.Drawing.Point(8, 26);
            this.label_serialPort.Name = "label_serialPort";
            this.label_serialPort.Size = new System.Drawing.Size(75, 16);
            this.label_serialPort.TabIndex = 15;
            this.label_serialPort.Text = "Serial Port: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 16);
            this.label2.TabIndex = 15;
            this.label2.Text = "Server IP:";
            // 
            // button_saveStart
            // 
            this.button_saveStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_saveStart.Location = new System.Drawing.Point(195, 518);
            this.button_saveStart.Name = "button_saveStart";
            this.button_saveStart.Size = new System.Drawing.Size(116, 26);
            this.button_saveStart.TabIndex = 21;
            this.button_saveStart.Text = " Save and Start";
            this.button_saveStart.UseVisualStyleBackColor = true;
            this.button_saveStart.Click += new System.EventHandler(this.button_saveStart_Click);
            // 
            // groupBox_alarm
            // 
            this.groupBox_alarm.Controls.Add(this.checkBox_volumeRepeated);
            this.groupBox_alarm.Controls.Add(this.volLabel);
            this.groupBox_alarm.Controls.Add(this.slider_volume);
            this.groupBox_alarm.Controls.Add(this.button_testTones);
            this.groupBox_alarm.Controls.Add(this.label3);
            this.groupBox_alarm.Controls.Add(this.comboBox_tones);
            this.groupBox_alarm.Controls.Add(this.label4);
            this.groupBox_alarm.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_alarm.Location = new System.Drawing.Point(12, 333);
            this.groupBox_alarm.Name = "groupBox_alarm";
            this.groupBox_alarm.Size = new System.Drawing.Size(299, 179);
            this.groupBox_alarm.TabIndex = 18;
            this.groupBox_alarm.TabStop = false;
            this.groupBox_alarm.Text = "Alarm Configuration:  ";
            // 
            // checkBox_volumeRepeated
            // 
            this.checkBox_volumeRepeated.AutoSize = true;
            this.checkBox_volumeRepeated.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_volumeRepeated.Location = new System.Drawing.Point(12, 117);
            this.checkBox_volumeRepeated.Name = "checkBox_volumeRepeated";
            this.checkBox_volumeRepeated.Size = new System.Drawing.Size(87, 20);
            this.checkBox_volumeRepeated.TabIndex = 21;
            this.checkBox_volumeRepeated.Text = "Repeated";
            this.checkBox_volumeRepeated.UseVisualStyleBackColor = true;
            // 
            // volLabel
            // 
            this.volLabel.AutoSize = true;
            this.volLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.volLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.volLabel.Location = new System.Drawing.Point(199, 71);
            this.volLabel.Name = "volLabel";
            this.volLabel.Size = new System.Drawing.Size(14, 16);
            this.volLabel.TabIndex = 19;
            this.volLabel.Text = "0";
            // 
            // slider_volume
            // 
            this.slider_volume.Location = new System.Drawing.Point(65, 66);
            this.slider_volume.Maximum = 100;
            this.slider_volume.Name = "slider_volume";
            this.slider_volume.Size = new System.Drawing.Size(130, 45);
            this.slider_volume.TabIndex = 18;
            this.slider_volume.TickFrequency = 10;
            this.slider_volume.Scroll += new System.EventHandler(this.volumeSlider_Scroll);
            // 
            // button_testTones
            // 
            this.button_testTones.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_testTones.Location = new System.Drawing.Point(213, 143);
            this.button_testTones.Name = "button_testTones";
            this.button_testTones.Size = new System.Drawing.Size(78, 26);
            this.button_testTones.TabIndex = 4;
            this.button_testTones.Text = "Test Tone";
            this.button_testTones.UseVisualStyleBackColor = true;
            this.button_testTones.Click += new System.EventHandler(this.button_testTones_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 17;
            this.label3.Text = "Volume:";
            // 
            // comboBox_tones
            // 
            this.comboBox_tones.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.comboBox_tones.BackColor = System.Drawing.SystemColors.Window;
            this.comboBox_tones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_tones.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBox_tones.ForeColor = System.Drawing.SystemColors.WindowText;
            this.comboBox_tones.FormattingEnabled = true;
            this.comboBox_tones.ItemHeight = 18;
            this.comboBox_tones.Location = new System.Drawing.Point(92, 34);
            this.comboBox_tones.MaxDropDownItems = 5;
            this.comboBox_tones.Name = "comboBox_tones";
            this.comboBox_tones.Size = new System.Drawing.Size(184, 26);
            this.comboBox_tones.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 16);
            this.label4.TabIndex = 15;
            this.label4.Text = "Alarm Tone:";
            // 
            // button_connect
            // 
            this.button_connect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_connect.Location = new System.Drawing.Point(77, 518);
            this.button_connect.Name = "button_connect";
            this.button_connect.Size = new System.Drawing.Size(112, 26);
            this.button_connect.TabIndex = 18;
            this.button_connect.Text = "Connect Serial";
            this.button_connect.UseVisualStyleBackColor = true;
            this.button_connect.Click += new System.EventHandler(this.button_connect_Click);
            // 
            // serialPort_control
            // 
            this.serialPort_control.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_control_DataReceived);
            // 
            // dataGridView_curCheckout
            // 
            this.dataGridView_curCheckout.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_curCheckout.Location = new System.Drawing.Point(452, 41);
            this.dataGridView_curCheckout.Name = "dataGridView_curCheckout";
            this.dataGridView_curCheckout.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridView_curCheckout.Size = new System.Drawing.Size(488, 355);
            this.dataGridView_curCheckout.TabIndex = 24;
            this.dataGridView_curCheckout.MouseLeave += new System.EventHandler(this.dataGridView_curCheckout_MouseLeave);
            this.dataGridView_curCheckout.MouseHover += new System.EventHandler(this.dataGridView_curCheckout_MouseHover);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(317, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 16);
            this.label5.TabIndex = 24;
            this.label5.Text = " Tag Monitor:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(449, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(198, 16);
            this.label6.TabIndex = 25;
            this.label6.Text = "Currently Checked out Materials:";
            // 
            // usbBackgroundWorker
            // 
            this.usbBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.usbBackgroundWorker_DoWork);
            // 
            // richTextBox_serialReceived
            // 
            this.richTextBox_serialReceived.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox_serialReceived.Location = new System.Drawing.Point(318, 42);
            this.richTextBox_serialReceived.Name = "richTextBox_serialReceived";
            this.richTextBox_serialReceived.Size = new System.Drawing.Size(128, 354);
            this.richTextBox_serialReceived.TabIndex = 26;
            this.richTextBox_serialReceived.Text = "";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 556);
            this.Controls.Add(this.richTextBox_serialReceived);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dataGridView_curCheckout);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox_SerialConfig);
            this.Controls.Add(this.groupBox_alarm);
            this.Controls.Add(this.button_saveStart);
            this.Controls.Add(this.button_connect);
            this.Name = "Main";
            this.Text = "Koha RFID Solution";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox_SerialConfig.ResumeLayout(false);
            this.groupBox_SerialConfig.PerformLayout();
            this.groupBox_alarm.ResumeLayout(false);
            this.groupBox_alarm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.slider_volume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_curCheckout)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox_SerialConfig;
        private System.Windows.Forms.GroupBox groupBox_alarm;
        private System.Windows.Forms.Label volLabel;
        private System.Windows.Forms.TrackBar slider_volume;
        private System.Windows.Forms.Button button_testTones;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_tones;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_connect;
        private System.Windows.Forms.ComboBox comboBox_baudRate;
        private System.Windows.Forms.TextBox textbox_Creportno;
        private System.Windows.Forms.Label label_baudRate;
        private System.Windows.Forms.TextBox textbox_serverip;
        private System.Windows.Forms.ComboBox comboBox_serialPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_serialPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_help;
        private System.IO.Ports.SerialPort serialPort_control;
        private System.Windows.Forms.Button button_saveStart;
        private System.Windows.Forms.Label label_invalidIP;
        private System.Windows.Forms.Label label_invalidReport;
        private System.Windows.Forms.DataGridView dataGridView_curCheckout;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox checkBox_volumeRepeated;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox_TreportNo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.ComponentModel.BackgroundWorker usbBackgroundWorker;
        private System.Windows.Forms.RichTextBox richTextBox_serialReceived;
        private System.Windows.Forms.ComboBox comboBox_removeExtra;
        private System.Windows.Forms.Label label_removeExtra;
    }
}

