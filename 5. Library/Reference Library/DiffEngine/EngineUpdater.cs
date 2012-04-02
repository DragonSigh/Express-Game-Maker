using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using EGMGame.Controls;
using EGMGame.Library;
using System.ComponentModel;
using System.Collections;
using System.Reflection;
using Microsoft.Xna.Framework.Content;

namespace EGMGame.DiffEngine
{
    public class EngineUpdater
    {
        public static void Update(string path, int version, int newVersion)
        {
            switch (version)
            {
                case 0:
                    UpdateVersion1(path);
                    Update(path, newVersion, newVersion + 1);
                    break;
                case 1:
                    break;
            }
        }


        #region Update Version 1
        static string[] version1Files = new string[]
        {
            "Project.egmproj"
        };

        private static void UpdateVersion1(string path)
        {
            string fullPath;
            // Replace xmlns:Library="EGMGame.Library" with xmlns:Library="EGMGame.Library_v1"
            foreach (string file in version1Files)
            {
                fullPath = path + file;
                Replace(fullPath, "xmlns:Library=" + '"' + "EGMGame.Library" + '"', "xmlns:Library=" + '"' + "EGMGame.Library_v1" + '"');
            }
            // Only Load What is necessary
            EGMGame.Library_v1.Project project = Marshal.LoadData<EGMGame.Library_v1.Project>(path + version1Files[0]);
            // Create New Data
            Project _project = new Project();
            // Convert Data
            Convert(project, _project, typeof(EGMGame.Library_v1.Project), typeof(Project));
            // Save it back
            Marshal.SaveObj(_project, path + version1Files[0], path);
        }

        #endregion

        #region Helpers
        static void Convert(object older, object newer, Type olderType, Type newType)
        {
            IEnumerable<PropertyInfo> properties = GetPropertyInfo(olderType);
            IEnumerable<FieldInfo> fields = GetFieldInfo(olderType);

            IEnumerable<string> _properties = GetProperties(newType);
            IEnumerable<string> _fields = GetFields(newType);

            foreach (PropertyInfo info in properties)
            {
                if (_properties.Contains(info.Name))
                {
                    newer.GetType().GetProperty(info.Name).SetValue(newer, info.GetValue(older, null), null);
                }
                else if (_fields.Contains(info.Name))
                {
                    newer.GetType().GetField(info.Name).SetValue(newer, info.GetValue(older, null));
                }
            }

            foreach (FieldInfo info in fields)
            {
                if (_fields.Contains(info.Name))
                {
                    newer.GetType().GetField(info.Name).SetValue(newer, info.GetValue(older));
                }
                else if (_properties.Contains(info.Name))
                {
                    newer.GetType().GetProperty(info.Name).SetValue(newer, info.GetValue(older), null);
                }
            }
        }
        /// <summary>
        /// method for replacing certain text in a text file
        /// </summary>
        /// <param name="file">file we're looking in (include full path)</param>
        /// <param name="searchFor">text we're looking for</param>
        /// <param name="replaceWith">text to replace it with</param>
        /// <returns></returns>
        public static bool Replace(string file, string searchFor, string replaceWith)
        {
            try
            {
                string contents = "";
                //get a StreamReader for reading the file
                using (StreamReader reader = new StreamReader(file))
                {

                    //read the entire file at once
                    contents = reader.ReadToEnd();

                    //close up and dispose
                    reader.Close();
                    reader.Dispose();
                }
                //use regular expressions to search and replace our text
                contents = Regex.Replace(contents, searchFor, replaceWith);

                //get a StreamWriter for writing the new text to the file
                using (StreamWriter writer = new StreamWriter(file))
                {
                    //write the contents
                    writer.Write(contents);

                    //close up and dispose
                    writer.Close();
                    writer.Dispose();
                }
                //return successful
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        ///   Caches and returns property info for a type
        /// </summary>
        /// <param name = "itm">The type that should have its property info returned</param>
        /// <returns>An enumeration of PropertyInfo objects</returns>
        /// <remarks>
        ///   It should be noted that the implementation converts the enumeration returned from reflection to an array as this more than double the speed of subsequent reads
        /// </remarks>
        private static IEnumerable<PropertyInfo> GetPropertyInfo(Type itm)
        {
            IEnumerable<PropertyInfo> ret;

            ret = itm.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy).Where(p => p.GetCustomAttributes(typeof(DoNotSerialize), false).Count() == 0 && p.GetCustomAttributes(typeof(ContentSerializerIgnoreAttribute), false).Count() == 0 && !(p.GetIndexParameters().Count() > 0) && (p.GetSetMethod() != null) && (p.GetGetMethod() != null)).ToArray();
            return ret;
        }
        /// <summary>
        ///   Caches and returns field info for a type
        /// </summary>
        /// <param name = "itm">The type that should have its field info returned</param>
        /// <returns>An enumeration of FieldInfo objects</returns>
        /// <remarks>
        ///   It should be noted that the implementation converts the enumeration returned from reflection to an array as this more than double the speed of subsequent reads
        /// </remarks>
        private static IEnumerable<FieldInfo> GetFieldInfo(Type itm)
        {
            return itm.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy | BindingFlags.SetField).Where(p => p.GetCustomAttributes(typeof(DoNotSerialize), false).Count() == 0 && p.GetCustomAttributes(typeof(ContentSerializerIgnoreAttribute), false).Count() == 0).ToArray();
        }
        private static IEnumerable<string> GetProperties(Type itm)
        {
            IEnumerable<PropertyInfo> ret;

            ret = itm.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy).Where(p => p.GetCustomAttributes(typeof(DoNotSerialize), false).Count() == 0 && p.GetCustomAttributes(typeof(ContentSerializerIgnoreAttribute), false).Count() == 0 && !(p.GetIndexParameters().Count() > 0) && (p.GetSetMethod() != null) && (p.GetGetMethod() != null)).ToArray();
            List<string> list = new List<string>();
            foreach (PropertyInfo field in ret)
            {
                list.Add(field.Name);
            }
            return list;
        }
        private static IEnumerable<string> GetFields(Type itm)
        {
            IEnumerable<FieldInfo> fields = itm.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy | BindingFlags.SetField).Where(p => p.GetCustomAttributes(typeof(DoNotSerialize), false).Count() == 0 && p.GetCustomAttributes(typeof(ContentSerializerIgnoreAttribute), false).Count() == 0).ToArray();
            List<string> list = new List<string>();
            foreach (FieldInfo field in fields)
            {
                list.Add(field.Name);
            }
            return list;
        }

        #endregion
    }
}
