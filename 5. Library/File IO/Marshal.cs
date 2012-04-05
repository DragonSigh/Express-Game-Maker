//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Intermediate;

namespace EGMGame.Library
{
    internal class Marshal
    {
        internal static Dictionary<Type, XmlSerializer> xmlSerializers = new Dictionary<Type, XmlSerializer>();
        /// <summary>
        /// Saves any object in XML form 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="location"></param>
        /// <param name="dir"></param>
        internal static void SaveObj(object obj, string location, string dir)
        {
            try
            {
                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);

                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                using ( XmlWriter writer = XmlWriter.Create(location, settings))
                {
                    IntermediateSerializer.Serialize(writer, obj, null);
                }
                // Silverlight
                if (Path.GetFileName(location) != "Config.xml" && Global.Project != null)
                {
                    byte[] bytes = SilverlightSerializer.Serialize(obj);
                    if (!Directory.Exists(Global.Project.Location + @"\Silverlight\"))
                        Directory.CreateDirectory(Global.Project.Location + @"\Silverlight\");
                    FileInfo file = new FileInfo(Global.Project.Location + @"\Silverlight\" + Path.GetFileName(location));
                    FileStream stream = file.OpenWrite();
                    stream.Write(bytes, 0, bytes.Length);
                    stream.Close();
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "30x001");
            }
        }
        /// <summary>
        /// Load XML data from path.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="filename"></param>
        /// <returns></returns>
        internal static DType LoadData<DType>(string path)
        {
            try
            {
                if (path.Contains("Config.xml"))
                {
                    XmlReaderSettings settings = new XmlReaderSettings();

                    using (XmlReader reader = XmlReader.Create(path, settings))
                    {

                        return IntermediateSerializer.Deserialize<DType>(reader, path);
                    }
                }
                else if (File.Exists(path))
                {
                    XmlReaderSettings settings = new XmlReaderSettings();

                    using (XmlReader reader = XmlReader.Create(path, settings))
                    {
                        return IntermediateSerializer.Deserialize<DType>(reader, path);
                    }
                    return Activator.CreateInstance<DType>();


                    string dir = (new FileInfo(path)).DirectoryName;
                    path = dir + @"\Silverlight\" + Path.GetFileName(path);
                    using (Stream stream = File.OpenRead(path))
                    {
                        byte[] bytes = new byte[stream.Length];
                        stream.Position = 0;
                        stream.Read(bytes, 0, (int)stream.Length);
                        return (DType)SilverlightSerializer.Deserialize(bytes);
                    }
                }
            }
            catch (Exception ex)
            {
                if (path.Contains("Config.xml"))
                {
                    File.Delete(path);
                    MainForm.Configuration = new Config();
                    Config.Save();
                    return (DType)(object)MainForm.Configuration;
                }
                else
                {
                    try
                    {
                        string dir = (new FileInfo(path)).Directory.FullName;
                        if (Global.Project.Location != null)
                            path = Global.Project.Location + @"\Silverlight\" + Path.GetFileName(path);
                        else
                            path = dir + @"\Silverlight\" + Path.GetFileName(path); 
                        using (Stream stream = File.OpenRead(path))
                        {
                            byte[] bytes = new byte[stream.Length];
                            stream.Position = 0;
                            stream.Read(bytes, 0, (int)stream.Length);
                            return (DType)SilverlightSerializer.Deserialize(bytes);
                        }
                    }
                    catch
                    {
                        ex.StackTrace.Insert(0, "Error loading " + typeof(DType).ToString());
                        Error.ShowLogError(ex, "30x002");
                        MessageBox.Show(path);
                    }
                }
            }
            return Activator.CreateInstance<DType>();
        }
        /// <summary>
        /// Load data from stream.
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        internal static DataType LoadData<DataType>(Stream stream)
        {
            try
            {
                DataType data;
                XmlSerializer s = Marshal.CheckCache(typeof(DataType));
                TextReader r = new StreamReader(stream);
                data = (DataType)s.Deserialize(r);
                r.Close();
                return data;
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "30x005");
            }
            return default(DataType);
        }
        /// <summary>
        /// Saves any object in Binary form
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="location"></param>
        /// <param name="dir"></param>
        internal static void SaveBinObj(object obj, string location, string dir)
        {
            try
            {
                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);
                FileStream f = File.Create(location);
                BinaryFormatter b = new BinaryFormatter();
                b.Serialize(f, obj);
                f.Close();
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "30x003");
            }
        }
        /// <summary>
        /// Loads and returns saved binary object from file
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="filename"></param>
        /// <returns></returns>
        internal static object LoadBinObj(object obj, string filename)
        {
            try
            {
                FileStream s = File.Open(filename, FileMode.Open);
                BinaryFormatter b = new BinaryFormatter();
                obj = b.Deserialize(s);
                s.Close();
                return obj;
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "30x004");
            }
            return null;
        }
        /// <summary>
        /// Check cache for an existing serializer.
        /// If the serializer does not exist, return a new one.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        internal static XmlSerializer CheckCache(Type type)
        {
            XmlSerializer s;
            s = new XmlSerializer(type);
            xmlSerializers.Add(type, s);
            return s;
        }
        /// <summary>
        /// Clear Serializer Cache
        /// </summary>
        internal static void Clear()
        {
            xmlSerializers.Clear();
            GC.Collect();
        }
    }
}
