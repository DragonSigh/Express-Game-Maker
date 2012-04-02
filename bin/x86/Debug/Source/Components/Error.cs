//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com
//* All rights reserved.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EGMGame.Library;

namespace EGMGame.Components
{
    public class Error
    {
        /// <summary>
        /// When an error is catched, it is reported here.
        /// Once reported, the error is stored and displayed to the player.
        /// ErrorLevel is used to calculate how much of the error should be displayed. 
        /// </summary>
        /// <param name="ex"></param>
        public static void Do(Exception ex)
        {
            string message = ex.Message;
#if WINDOWS
            if (ex.TargetSite != null)
                message += " \n " + ex.TargetSite.ToString();
#endif
            if (ex.StackTrace != null)
                message += " \n " + ex.StackTrace.ToString();
            Global.Log(message);
#if WINDOWS
            string m_sLogFormat = "[2T]" + DateTime.Now.ToShortDateString().ToString() + "-" + DateTime.Now.ToLongTimeString().ToString();
            string sYear = DateTime.Now.Year.ToString();
            string sMonth = DateTime.Now.Month.ToString();
            string sDay = DateTime.Now.Day.ToString();
            string m_sErrorTime = sYear + "-" + sMonth + "-" + sDay;
            string path = m_sErrorTime + ".xml";
            System.IO.Stream xmlFile;
            if (!System.IO.File.Exists(path))
               xmlFile = System.IO.File.Create(path);
            else
                xmlFile = new System.IO.FileStream(path, System.IO.FileMode.Append);
            System.Xml.XmlTextWriter textWriter = new System.Xml.XmlTextWriter(xmlFile, Encoding.Default);
            // Opens the document
            textWriter.Formatting = System.Xml.Formatting.Indented;
            bool n = (xmlFile.Position == 0);
            if (n)
                textWriter.WriteStartDocument();
            textWriter.WriteComment(m_sLogFormat);
            textWriter.WriteStartElement("Error");
            // Write first element
            textWriter.WriteStartElement("Message");
            textWriter.WriteString(ex.Message);
            textWriter.WriteEndElement();
            // Write next element
            textWriter.WriteStartElement("TargetSite");
            if (ex.TargetSite != null)
            {
                textWriter.WriteString(ex.TargetSite.Name);
                textWriter.WriteEndElement();
            }
            // Write next element
            textWriter.WriteStartElement("Source");
            textWriter.WriteString(ex.Source);
            textWriter.WriteEndElement();
            // Write next element
            textWriter.WriteStartElement("StackTrace");
            textWriter.WriteString(ex.StackTrace);
            textWriter.WriteEndElement();
            // Write next element
            if (ex.InnerException != null)
            {
                textWriter.WriteStartElement("Inner_Exception_Message");
                textWriter.WriteString(ex.InnerException.Message);
                textWriter.WriteEndElement();
                // Write next element
                textWriter.WriteStartElement("Inner_Exception_Source");
                textWriter.WriteString(ex.InnerException.Source);
                textWriter.WriteEndElement();
                // Write next element
                textWriter.WriteStartElement("Inner_Exception_StackTrace");
                textWriter.WriteString(ex.InnerException.StackTrace);
                textWriter.WriteEndElement();
            }
            // End the first element
            textWriter.WriteEndElement();
            // Ends the document.
            if (n)
                textWriter.WriteEndDocument();
            // close writer
            textWriter.Close();
#endif

#if WINDOWS && DEBUG && !VISUAL
            MessageBox(new IntPtr(0), "[" + DateTime.Now.ToShortDateString() + "] : " + message.ToString(), "Game Error", 0);
#endif
            // 0 - "An error has occured."
            // 1 - "[ErrorMessage]"
            // 2 - "[ErrorMessaeg] [Source]"
            // 3 - "[ErrorMessaeg] [Source] [Statck]"
            switch (Global.ErrorLevel)
            {
                case 0:

                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
            }
        }
        

#if WINDOWS
        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        public static extern uint MessageBox(IntPtr hWnd, String text, String caption, uint type);
#endif
    }
}
