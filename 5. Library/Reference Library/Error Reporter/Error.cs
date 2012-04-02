using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using EGMGame.Dialogs;
using System.Net;
using System.Management;

namespace EGMGame
{
    public class Error
    {
        internal static void ShowLogError(Exception e, string code)
        {
            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv") return;
            string m_sLogFormat = "[2T]" + DateTime.Now.ToShortDateString().ToString() + "-" + DateTime.Now.ToLongTimeString().ToString();
            string sYear = DateTime.Now.Year.ToString();
            string sMonth = DateTime.Now.Month.ToString();
            string sDay = DateTime.Now.Day.ToString();
            string m_sErrorTime = "";// = sYear + "-" + sMonth + "-" + sDay;
            string path = Application.StartupPath + @"\" + Global.Username + "_ErrorLog";

            bool writePCInfo = false;
            string version = Global.EgmVersion;
            version = version.Replace(".", "_");

            if (!File.Exists(path + m_sErrorTime + version + ".xml"))
                writePCInfo = true;
            Stream xmlFile = new FileStream(path + m_sErrorTime + version + ".xml", FileMode.Append);


            XmlTextWriter textWriter = new XmlTextWriter(xmlFile, Encoding.Default);
            // Opens the document
            textWriter.Formatting = Formatting.Indented;
            bool n = (xmlFile.Position == 0);
            if (n)
                textWriter.WriteStartDocument();

            if (writePCInfo && n)
            {
                WritePCINFO(textWriter);
                // Ends the document.
                textWriter.WriteEndDocument();
                // close writer
                textWriter.Close();

                xmlFile = new FileStream(path + m_sErrorTime + version + ".xml", FileMode.Append);
                textWriter = new XmlTextWriter(xmlFile, Encoding.Default);
            }
            textWriter.WriteComment(m_sLogFormat);
            textWriter.WriteStartElement("Error");
            // Write first element
            textWriter.WriteStartElement("Code");
            textWriter.WriteString(code);
            textWriter.WriteEndElement();
            // Write first element
            textWriter.WriteStartElement("Message");
            textWriter.WriteString(e.Message);
            textWriter.WriteEndElement();
            // Write next element
            textWriter.WriteStartElement("TargetSite");
            if (e.TargetSite != null)
            {
                textWriter.WriteString(e.TargetSite.Name);
                textWriter.WriteEndElement();
            }
            // Write next element
            textWriter.WriteStartElement("Source");
            textWriter.WriteString(e.Source);
            textWriter.WriteEndElement();
            // Write next element
            textWriter.WriteStartElement("StackTrace");
            textWriter.WriteString(e.StackTrace);
            textWriter.WriteEndElement();
            // Write next element
            if (e.InnerException != null)
            {
                textWriter.WriteStartElement("Inner_Exception_Message");
                textWriter.WriteString(e.InnerException.Message);
                textWriter.WriteEndElement();
                // Write next element
                textWriter.WriteStartElement("Inner_Exception_Source");
                textWriter.WriteString(e.InnerException.Source);
                textWriter.WriteEndElement();
                // Write next element
                textWriter.WriteStartElement("Inner_Exception_StackTrace");
                textWriter.WriteString(e.InnerException.StackTrace);
                textWriter.WriteEndElement();
            }
            // Write User Message
            string userMessage = ErrorDisplayDialog.Show(code, e.Message);
            // Write next element
            textWriter.WriteStartElement("UserMessage");
            textWriter.WriteString(userMessage);
            textWriter.WriteEndElement();
            // End the first element
            textWriter.WriteEndElement();
            // Ends the document.
            if (n)
                textWriter.WriteEndDocument();
            // close writer
            textWriter.Close();
        }

        private static void WritePCINFO(XmlTextWriter textWriter)
        {
            string info;
            textWriter.WriteStartElement("INFORMATION");

            textWriter.WriteStartElement("RAM");
            info = GetRam();
            textWriter.WriteString(info);
            textWriter.WriteEndElement();

            textWriter.WriteStartElement("CAPTION");
            info = GetCpuCaption();
            textWriter.WriteString(info);
            textWriter.WriteEndElement();

            info = GetCpuCores().ToString();
            textWriter.WriteStartElement("CORES");
            textWriter.WriteString(info);
            textWriter.WriteEndElement();

            info = GetCpuSocketDesignation().ToString();
            textWriter.WriteStartElement("SOCKET");
            textWriter.WriteString(info);
            textWriter.WriteEndElement();

            info = GetCpuManufacturer();
            textWriter.WriteStartElement("MANUFACTURER");
            textWriter.WriteString(info);
            textWriter.WriteEndElement();

            info = GetCpuNumberOfLogicalProcessors().ToString();
            textWriter.WriteStartElement("LOGICAL");
            textWriter.WriteString(info);
            textWriter.WriteEndElement();

            info = GetCpuClockSpeed().ToString();
            textWriter.WriteStartElement("SPEED");
            textWriter.WriteString(info);
            textWriter.WriteEndElement();

            info = GetCpuDataWidth().ToString();
            textWriter.WriteStartElement("DATA_WIDTH");
            textWriter.WriteString(info);
            textWriter.WriteEndElement();

            info = GetGFXCaption();
            textWriter.WriteStartElement("GFX CAPTION");
            textWriter.WriteString(info);
            textWriter.WriteEndElement();

            info = GetGFXRam();
            textWriter.WriteStartElement("GFX RAM");
            textWriter.WriteString(info);
            textWriter.WriteEndElement();

            info = GetVideoRAM();
            textWriter.WriteStartElement("GFX_VIDEO_MEMORY_TYPE");
            textWriter.WriteString(info);
            textWriter.WriteEndElement();

            textWriter.WriteEndElement();
        }

        internal static void ShowError(Exception e)
        {
            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv") return;
            string text = e.Message + " This error has been logged.";
            MessageBox.Show(text, e.Source, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        }

        internal static void LogError(Exception e, string code)
        {
            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv") return;
            string m_sLogFormat = "[2T]" + DateTime.Now.ToShortDateString().ToString() + "-" + DateTime.Now.ToLongTimeString().ToString();
            string sYear = DateTime.Now.Year.ToString();
            string sMonth = DateTime.Now.Month.ToString();
            string sDay = DateTime.Now.Day.ToString();
            string m_sErrorTime = "";// = sYear + "-" + sMonth + "-" + sDay;
            string path = Application.StartupPath + @"\" + Global.Username + "_ErrorLog";

            bool writePCInfo = false;
            string version = Global.EgmVersion;
            version = version.Replace(".", "_");

            if (!File.Exists(path + m_sErrorTime + version + ".xml"))
                writePCInfo = true;
            Stream xmlFile = new FileStream(path + m_sErrorTime + version + ".xml", FileMode.Append);


            XmlTextWriter textWriter = new XmlTextWriter(xmlFile, Encoding.Default);
            // Opens the document
            textWriter.Formatting = Formatting.Indented;
            bool n = (xmlFile.Position == 0);
            if (n)
                textWriter.WriteStartDocument();

            if (writePCInfo)
            {
                WritePCINFO(textWriter);
            }
            textWriter.WriteComment(m_sLogFormat);
            textWriter.WriteStartElement("Error");
            // Write first element
            textWriter.WriteStartElement("Code");
            textWriter.WriteString(code);
            textWriter.WriteEndElement();
            // Write first element
            textWriter.WriteStartElement("Message");
            textWriter.WriteString(e.Message);
            textWriter.WriteEndElement();
            // Write next element
            textWriter.WriteStartElement("TargetSite");
            if (e.TargetSite != null)
            {
                textWriter.WriteString(e.TargetSite.Name);
                textWriter.WriteEndElement();
            }
            // Write next element
            textWriter.WriteStartElement("Source");
            textWriter.WriteString(e.Source);
            textWriter.WriteEndElement();
            // Write next element
            textWriter.WriteStartElement("StackTrace");
            textWriter.WriteString(e.StackTrace);
            textWriter.WriteEndElement();
            // Write next element
            if (e.InnerException != null)
            {
                textWriter.WriteStartElement("Inner_Exception_Message");
                textWriter.WriteString(e.InnerException.Message);
                textWriter.WriteEndElement();
                // Write next element
                textWriter.WriteStartElement("Inner_Exception_Source");
                textWriter.WriteString(e.InnerException.Source);
                textWriter.WriteEndElement();
                // Write next element
                textWriter.WriteStartElement("Inner_Exception_StackTrace");
                textWriter.WriteString(e.InnerException.StackTrace);
                textWriter.WriteEndElement();
            }
            // Write User Message
            string userMessage = "";
            // Write next element
            textWriter.WriteStartElement("UserMessage");
            textWriter.WriteString(userMessage);
            textWriter.WriteEndElement();
            // End the first element
            textWriter.WriteEndElement();
            // Ends the document.
            if (n)
                textWriter.WriteEndDocument();
            // close writer
            textWriter.Close();
        }

        internal static void Log(string text)
        {
            return;
            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv") return;
            string m_sLogFormat = "[2T]" + DateTime.Now.ToShortDateString().ToString() + "-" + DateTime.Now.ToLongTimeString().ToString();
            string sYear = DateTime.Now.Year.ToString();
            string sMonth = DateTime.Now.Month.ToString();
            string sDay = DateTime.Now.Day.ToString();
            string m_sErrorTime = sYear + "-" + sMonth + "-" + sDay;
            string path = Application.StartupPath + @"\Error ";
            Stream xmlFile = new FileStream(path + m_sErrorTime + ".xml", FileMode.Append);
            XmlTextWriter textWriter = new XmlTextWriter(xmlFile, Encoding.Default);
            // Opens the documentk
            textWriter.Formatting = Formatting.Indented;
            bool n = (xmlFile.Position == 0);
            if (n)
                textWriter.WriteStartDocument();
            textWriter.WriteComment(m_sLogFormat);

            textWriter.WriteStartElement("Error");
            // Write first element
            textWriter.WriteStartElement("Message");
            textWriter.WriteString(text);
            textWriter.WriteEndElement();

            // End the first element
            textWriter.WriteEndElement();
            // Ends the document.
            if (n)
                textWriter.WriteEndDocument();
            // close writer
            textWriter.Close();
        }

        internal static void UploadFile()
        {
            string filePath = Application.StartupPath + @"\" + Global.Username + "_ErrorLog";

            if (File.Exists(filePath))
            {
                //Create FTP request
                FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(@"ftp://expressgamemaker.com/Errors/" + Path.GetFileName(filePath));

                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential("EgmErrorUploader", "32!0-.no$way%is&this.way"); // username, password
                request.UsePassive = true;
                request.UseBinary = true;
                request.KeepAlive = false;

                //Load the file
                FileStream stream = File.OpenRead(filePath);
                byte[] buffer = new byte[stream.Length];

                stream.Read(buffer, 0, buffer.Length);
                stream.Close();

                //Upload file
                Stream reqStream = request.GetRequestStream();
                reqStream.Write(buffer, 0, buffer.Length);
                reqStream.Close();
#if DEBUG
                MessageBox.Show("Uploaded Successfully");
#endif
            }
        }

        static string GetRam()
        {
            double totalCapacity = 0;

            ObjectQuery objectQuery = new ObjectQuery("select * from Win32_PhysicalMemory");
            ManagementObjectSearcher searcher = new
            ManagementObjectSearcher(objectQuery);
            ManagementObjectCollection vals = searcher.Get();

            foreach (ManagementObject val in vals)
            {
                totalCapacity += System.Convert.ToDouble(val.GetPropertyValue("Capacity"));
            }

            return ((totalCapacity / 1048576) + " MB");
        }
        //Get the Caption of the Cpu (some rando-memum of the Cpu)
        public static string GetCpuCaption()
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2",
                    "SELECT * FROM Win32_Processor");

                foreach (ManagementObject queryObj in searcher.Get())
                {
                    return queryObj["Caption"].ToString();
                }
            }
            catch (Exception e)
            {
                return null;
            }
            return null;
        }

        //Get the current operating voltage of the Cpu
        public static int GetCpuVoltage()
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2",
                    "SELECT * FROM Win32_Processor");

                foreach (ManagementObject queryObj in searcher.Get())
                {
                    return Convert.ToInt32(queryObj["CurrentVoltage"]);
                }
            }
            catch (Exception e)
            {
                return -1;
            }
            return -1;
        }

        //Dual core? Quad-core? "Many-core"?  http://en.wikipedia.org/wiki/Many-core_processing_unit
        public static int GetCpuCores()
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2",
                    "SELECT * FROM Win32_Processor");

                foreach (ManagementObject queryObj in searcher.Get())
                {
                    return Convert.ToInt32(queryObj["NumberOfCores"]);
                }
            }
            catch (ManagementException e)
            {
                return -1;
            }
            return -1;
        }

        //Cpu serial
        public static string GetCpuId()
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2",
                    "SELECT * FROM Win32_Processor");

                foreach (ManagementObject queryObj in searcher.Get())
                {
                    return queryObj["ProcessorId"].ToString();
                }
            }
            catch (ManagementException e)
            {
                return null;
            }
            return null;
        }

        //Cpu socket designation, more info here: http://en.wikipedia.org/wiki/CPU_socket
        public static string GetCpuSocketDesignation()
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2",
                    "SELECT * FROM Win32_Processor");

                foreach (ManagementObject queryObj in searcher.Get())
                {
                    return queryObj["SocketDesignation"].ToString();
                }
            }
            catch (Exception e)
            {
                return null;
            }
            return null;
        }

        // Intel vs AMD :)
        public static string GetCpuManufacturer()
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2",
                    "SELECT * FROM Win32_Processor");

                foreach (ManagementObject queryObj in searcher.Get())
                {
                    return queryObj["Manufacturer"].ToString();
                }
            }
            catch (Exception e)
            {
                return null;
            }
            return null;
        }

        //think hyper-threading
        public static int GetCpuNumberOfLogicalProcessors()
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2",
                    "SELECT * FROM Win32_Processor");

                foreach (ManagementObject queryObj in searcher.Get())
                {
                    return Convert.ToInt32(queryObj["NumberOfLogicalProcessors"]);
                }
            }
            catch (Exception e)
            {
                return -1;
            }
            return -1;
        }

        public static int GetCpuClockSpeed()
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2",
                    "SELECT * FROM Win32_Processor");

                foreach (ManagementObject queryObj in searcher.Get())
                {
                    return Convert.ToInt32(queryObj["CurrentClockSpeed"]);
                }
            }
            catch (Exception e)
            {
                return -1;
            }
            return -1;
        }

        //Reads whether you are running a 32 or 64 Bit system
        public static int GetCpuDataWidth()
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2",
                    "SELECT * FROM Win32_Processor");

                foreach (ManagementObject queryObj in searcher.Get())
                {
                    return Convert.ToInt32(queryObj["DataWidth"]);
                }
            }
            catch (Exception e)
            {
                return -1;
            }
            return -1;
        }
        //Reads whether you are running a 32 or 64 Bit system
        public static string GetGFXCaption()
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM  Win32_VideoController");

                foreach (ManagementObject queryObj in searcher.Get())
                {
                    return queryObj["Caption"].ToString();
                }
            }
            catch (Exception e)
            {
                return null;
            }
            return null;
        }

        private static string GetVideoRAM()
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM  Win32_VideoController");

                foreach (ManagementObject queryObj in searcher.Get())
                {
                    return Convert.ToInt32(queryObj["VideoMemoryType"]).ToString();
                }
            }
            catch (Exception e)
            {
                return "";
            }
            return "";
        }

        private static string GetGFXRam()
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM  Win32_VideoController");
                double totalCapacity = 0;
                foreach (ManagementObject val in searcher.Get())
                {
                    totalCapacity += System.Convert.ToDouble(val.GetPropertyValue("AdapterRAM"));
                }

                return ((totalCapacity / 1048576) + " MB");
            }
            catch (Exception e)
            {
                return "";
            }
        }

    }
}

//1

	

//Other

//2

	

//Unknown

//3

	

//VRAM

//4

	

//DRAM

//5

	

//SRAM

//6

	

//WRAM

//7

	

//EDO RAM

//8

	

//Burst Synchronous DRAM

//9

	

//Pipelined Burst SRAM

//10

	

//CDRAM

//11

	

//3DRAM

//12

	

//SDRAM

//13

	

//SGRAM
