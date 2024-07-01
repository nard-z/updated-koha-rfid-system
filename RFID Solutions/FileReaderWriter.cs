using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RFID_Solutions
{
    internal class FileReaderWriter
    {
        FileProtection fp = new FileProtection();
        public bool WriteConfigFile(string serialPort, string baudRate, string serverIP, string extras, string cReportNo, string tReportNo, string alarmTone, string volume, string volumeRepeated)
        {
            try
            {
                StreamWriter sw = new StreamWriter("C:\\Users\\" + Environment.UserName + "\\RFIDconfig.ksav");

                sw.WriteLine(fp.Encrypt(serialPort));
                sw.WriteLine(fp.Encrypt(baudRate));
                sw.WriteLine(fp.Encrypt(serverIP));
                sw.WriteLine(fp.Encrypt(extras));
                sw.WriteLine(fp.Encrypt(cReportNo));
                sw.WriteLine(fp.Encrypt(tReportNo));
                sw.WriteLine(fp.Encrypt(alarmTone));
                sw.WriteLine(fp.Encrypt(volume));
                sw.WriteLine(fp.Encrypt(volumeRepeated));
                sw.Close();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Exception: " + e.Message, "Error!");
                return false;
            }
        }

        public string[] ReadConfigFile()
        {
            string[] configArray = new string[9];
            try
            {
                StreamReader sr = new StreamReader("C:\\Users\\" + Environment.UserName + "\\RFIDconfig.ksav");
                for (int counter = 0; counter <= configArray.Length-1; counter++)
                {
                    configArray[counter] = fp.Decrypt(sr.ReadLine());
                }
                sr.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Exception: " + e.Message);
            }
            return configArray;
        }
    }
}
