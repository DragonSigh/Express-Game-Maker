#region

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Xml.Serialization;
#endregion

//Silverlight Serializer By Mike Talbot (whydoidoit.wordpress.com)
//Please feel free to modify and to ask any questions on my blog.

namespace EGMGame
{
    /// <summary>
    ///   Indicates that a property or field should not be serialized
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class DoNotSerialize : Attribute
    {
    }

    /// <summary>
    ///   Silverlight/.NET compatible binary serializer with suppression support
    ///   produces compact representations, suitable for further compression
    /// </summary>
    public static class CustomSerializer
    {
        private static readonly Dictionary<Type, IEnumerable<FieldInfo>> FieldLists = new Dictionary<Type, IEnumerable<FieldInfo>>();
        private static readonly Dictionary<string, IEnumerable<PropertyInfo>> PropertyLists = new Dictionary<string, IEnumerable<PropertyInfo>>();
#if !XBOX
        [ThreadStatic]
#endif
        private static List<Type> _knownTypes;
#if !XBOX
        [ThreadStatic]
#endif
        private static Dictionary<object, int> _seenObjects;
#if !XBOX
        [ThreadStatic]
#endif
        private static List<object> _loadedObjects;
#if !XBOX
        [ThreadStatic]
#endif
        private static List<string> _propertyIds;
#if !XBOX
        [ThreadStatic]
#endif
        private static Stack<List<object>> _loStack;
#if !XBOX
        [ThreadStatic]
#endif
        private static Stack<Dictionary<object, int>> _soStack;
#if !XBOX
        [ThreadStatic]
#endif
        private static Stack<List<Type>> _ktStack;
#if !XBOX
        [ThreadStatic]
#endif
        private static Stack<List<string>> _piStack;

        private static readonly Dictionary<Type, object> Vanilla = new Dictionary<Type, object>();

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
            lock (PropertyLists)
            {
                IEnumerable<PropertyInfo> ret;

                if (!PropertyLists.TryGetValue(itm.AssemblyQualifiedName, out ret))
                {
                    ret = itm.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy).Where(
                        p => p.GetCustomAttributes(typeof(DoNotSerialize), false).Count() == 0 &&
                            !(p.GetIndexParameters().Count() > 0) &&
                            (p.GetSetMethod() != null) && (p.GetGetMethod() != null) &&
                            p.GetCustomAttributes(typeof(XmlIgnoreAttribute), false).Count() == 0

                            ).ToArray();
                    PropertyLists[itm.AssemblyQualifiedName] = ret;
                }
                return ret;
            }
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
            lock (FieldLists)
            {
                if (FieldLists.ContainsKey(itm)) return FieldLists[itm];
                FieldLists[itm] = itm.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy | BindingFlags.SetField).Where(p => p.GetCustomAttributes(typeof(DoNotSerialize), false).Count() == 0 && p.GetCustomAttributes(typeof(XmlIgnoreAttribute), false).Count() == 0).ToArray();
                return FieldLists[itm];
            }
        }

        /// <summary>
        ///   Returns a token that represents the name of the property
        /// </summary>
        /// <param name = "name">The name for which to return a token</param>
        /// <returns>A 2 byte token representing the name</returns>
        private static ushort GetPropertyDefinitionId(string name)
        {
            lock (_propertyIds)
            {
                var ret = _propertyIds.IndexOf(name);
                if (ret >= 0) return (ushort)ret;
                _propertyIds.Add(name);
                return (ushort)(_propertyIds.Count - 1);
            }
        }

        /// <summary>
        ///   Convert a previously serialized object from a byte array 
        ///   back into a .NET object
        /// </summary>
        /// <param name = "bytes">The data stream for the object</param>
        /// <returns>The rehydrated object represented by the data supplied</returns>
        public static object Deserialize(byte[] bytes)
        {
            CreateStacks();
            try
            {
                _ktStack.Push(_knownTypes);
                _piStack.Push(_propertyIds);
                _loStack.Push(_loadedObjects);

                var strm = new MemoryStream(bytes);
                var rw = new BinaryReader(strm);
                var version = rw.ReadString();
                var count = rw.ReadInt32();
                _propertyIds = new List<string>();
                _knownTypes = new List<Type>();
                _loadedObjects = new List<object>();
                for (var i = 0; i < count; i++)
                {
                    string test = rw.ReadString();
                    if (test.Contains("ExpressGameMaker"))
                        test = test.Replace("ExpressGameMaker", "EGMGame");
                    var tp = Type.GetType(test);
                    if (tp == null)
                    {
                        // Retry but remove unneccesarry info.
                        string[] str = test.Split(',');
                        if (str.Length > 2)
                            test = str[0] + ", " + str[1] + ", " + str[2];
                        tp = Type.GetType(test);
                    }
                    _knownTypes.Add(tp);
                }
                count = rw.ReadInt32();
                for (var i = 0; i < count; i++)
                {
                    string test = rw.ReadString();
                    _propertyIds.Add(test);
                }

                return DeserializeObject(rw, null);
            }
            finally
            {
                _knownTypes = _ktStack.Pop();
                _propertyIds = _piStack.Pop();
                _loadedObjects = _loStack.Pop();
            }
        }

        /// <summary>
        ///   Creates a set of stacks on the current thread
        /// </summary>
        private static void CreateStacks()
        {
            if (_piStack == null) _piStack = new Stack<List<string>>();
            if (_ktStack == null) _ktStack = new Stack<List<Type>>();
            if (_loStack == null) _loStack = new Stack<List<object>>();
            if (_soStack == null) _soStack = new Stack<Dictionary<object, int>>();
        }

        /// <summary>
        ///   Deserializes an object or primitive from the stream
        /// </summary>
        /// <param name = "reader">The reader of the binary file</param>
        /// <param name = "itemType">The expected type of the item being read (supports compact format)</param>
        /// <returns>The value read from the file</returns>
        /// <remarks>
        ///   The function is supplied with the type of the property that the object was stored in (if known) this enables
        ///   a compact format where types only have to be specified if they differ from the expected one
        /// </remarks>
        private static object DeserializeObject(BinaryReader reader, Type itemType)
        {
            var tpId = (ushort)reader.ReadUInt16();
            if (tpId == 0xFFFE) return null;

            //Lookup the value type if necessary
            if (tpId != 0xffff) itemType = _knownTypes[tpId];
            //Debug.Assert(itemType != null);

            //Check if this is a simple value and read it if so
            if (IsSimpleType(itemType))
            {
                if (itemType.IsEnum)
                    return ReadValue(reader, typeof(int));
                return ReadValue(reader, itemType);
            }

            //See if we should lookup this object or create a new one
            var found = reader.ReadChar();
            if (found == 'S') //S is for Seen
            {
                int i = reader.ReadInt32();
                return _loadedObjects[i];
            }
            //Otherwise create the object
            if (itemType.IsArray) return DeserializeArray(itemType, reader);

            var obj = Activator.CreateInstance(itemType);
            if (!itemType.IsValueType)
                _loadedObjects.Add(obj);

            //Check for collection types)
            if (obj is IDictionary)
                return DeserializeDictionary(obj as IDictionary, itemType, reader);
            if (obj is IList)
                return DeserializeList(obj as IList, itemType, reader);
            if (obj is Vector2)
                return DeserializeVector2((Vector2)obj, itemType, reader);
            if (obj is Vector3)
                return DeserializeVector3((Vector3)obj, itemType, reader);
            if (obj is Vector4)
                return DeserializeVector4((Vector4)obj, itemType, reader);
            if (obj is Color)
                return DeserializeColor((Color)obj, itemType, reader);

            //Otherwise we are serializing an object
            return DeserializeObjectAndProperties(obj, itemType, reader);
        }

        private static object DeserializeColor(Color color, Type itemType, BinaryReader reader)
        {
            Color c = new Color();
            c.R = reader.ReadByte();
            c.G = reader.ReadByte();
            c.B = reader.ReadByte();
            c.A = reader.ReadByte();
            return c;
        }

        private static object DeserializeVector2(Vector2 vector, Type itemType, BinaryReader reader)
        {
            Vector2 v = new Vector2();
            v.X = reader.ReadSingle();
            v.Y = reader.ReadSingle();
            return v;
        }

        private static object DeserializeVector3(Vector3 vector, Type itemType, BinaryReader reader)
        {
            Vector3 v = new Vector3();
            v.X = reader.ReadSingle();
            v.Y = reader.ReadSingle();
            v.Z = reader.ReadSingle();
            return v;
        }

        private static object DeserializeVector4(Vector4 vector, Type itemType, BinaryReader reader)
        {
            Vector4 v = new Vector4();
            v.X = reader.ReadSingle();
            v.Y = reader.ReadSingle();
            v.Z = reader.ReadSingle();
            v.W = reader.ReadSingle();
            return v;
        }

        /// <summary>
        ///   Deserializes an array of values
        /// </summary>
        /// <param name = "itemType">The type of the array</param>
        /// <param name = "reader">The reader of the stream</param>
        /// <returns>The deserialized array</returns>
        /// <remarks>
        ///   This routine optimizes for arrays of primitives and bytes
        /// </remarks>
        private static object DeserializeArray(Type itemType, BinaryReader reader)
        {
            //Read the size of the array
            var count = reader.ReadInt32();
            //Get the expected element type
            var elementType = itemType.GetElementType();
            //Optimize for byte arrays
            if (elementType == typeof(byte))
            {
                var ret = reader.ReadBytes(count);
                _loadedObjects.Add(ret);
                return ret;
            }
            //Create an array of the correct type
            var array = Array.CreateInstance(elementType, count);
            _loadedObjects.Add(array);
            //Check whether the array contains primitives, if it does we don't
            //need to store the type of each member
            if (IsSimpleType(elementType))
                for (var l = 0; l < count; l++)
                {
                    array.SetValue(ReadValue(reader, elementType), l);
                }
            else
                for (var l = 0; l < count; l++)
                {
                    array.SetValue(DeserializeObject(reader, elementType), l);
                }

            return array;
        }

        /// <summary>
        ///   Deserializes a dictionary from storage, handles generic types with storage optimization
        /// </summary>
        /// <param name = "o">The newly created dictionary</param>
        /// <param name = "itemType">The type of the dictionary</param>
        /// <param name = "reader">The binary reader for the current bytes</param>
        /// <returns>The dictionary object updated with the values from storage</returns>
        private static object DeserializeDictionary(IDictionary o, Type itemType, BinaryReader reader)
        {
            Type keyType = null;
            Type valueType = null;
            if (itemType.IsGenericType)
            {
                var types = itemType.GetGenericArguments();
                keyType = types[0];
                valueType = types[1];
            }

            var count = reader.ReadInt32();
            var list = new List<object>();
            for (var i = 0; i < count; i++)
            {
                list.Add(DeserializeObject(reader, keyType));
            }
            for (var i = 0; i < count; i++)
            {
                o[list[i]] = DeserializeObject(reader, valueType);
            }
            return o;
        }

        /// <summary>
        ///   Deserialize a list from the data stream
        /// </summary>
        /// <param name = "o">The newly created list</param>
        /// <param name = "itemType">The type of the list</param>
        /// <param name = "reader">The reader for the current bytes</param>
        /// <returns>The list updated with values from the stream</returns>
        private static object DeserializeList(IList o, Type itemType, BinaryReader reader)
        {
            Type valueType = null;
            if (itemType.IsGenericType)
            {
                var types = itemType.GetGenericArguments();
                valueType = types[0];
            }

            var count = reader.ReadInt32();
            var list = new List<object>();
            for (var i = 0; i < count; i++)
            {
                o.Add(DeserializeObject(reader, valueType));
            }
            return o;
        }

        /// <summary>
        ///   Deserializes a class based object that is not a collection, looks for both public properties and fields
        /// </summary>
        /// <param name = "o">The object being deserialized</param>
        /// <param name = "itemType">The type of the object</param>
        /// <param name = "reader">The reader for the current stream of bytes</param>
        /// <returns>The object updated with values from the stream</returns>
        private static object DeserializeObjectAndProperties(object o, Type itemType, BinaryReader reader)
        {
            DeserializeProperties(reader, itemType, o);
            DeserializeFields(reader, itemType, o);
            return o;
        }

        /// <summary>
        ///   Deserializes the properties of an object from the stream
        /// </summary>
        /// <param name = "reader">The reader of the bytes in the stream</param>
        /// <param name = "itemType">The type of the object</param>
        /// <param name = "o">The object to deserialize</param>
        private static void DeserializeProperties(BinaryReader reader, Type itemType, object o)
        {
            //Get the number of properties
            var propCount = reader.ReadByte();
            for (var i = 0; i < propCount; i++)
            {
                //Get a property name identifier
                var propId = reader.ReadUInt16();
                //Lookup the name
                var propName = _propertyIds[propId];
                //Use the name to find the type
                var propType = itemType.GetProperty(propName);
                if (propType != null)
                {
                    //Deserialize the value
                    var value = DeserializeObject(reader, propType.PropertyType);
                    propType.SetValue(o, value, null);
                }
                else
                {
                    var fieldType = itemType.GetField(propName);
                    var value = DeserializeObject(reader, fieldType.FieldType);
                    fieldType.SetValue(o, value);
                }
            }
        }

        /// <summary>
        ///   Deserializes the fields of an object from the stream
        /// </summary>
        /// <param name = "reader">The reader of the bytes in the stream</param>
        /// <param name = "itemType">The type of the object</param>
        /// <param name = "o">The object to deserialize</param>
        private static void DeserializeFields(BinaryReader reader, Type itemType, object o)
        {
            var fieldCount = reader.ReadByte();
            for (var i = 0; i < fieldCount; i++)
            {
                var fieldId = reader.ReadUInt16();
                var fieldName = _propertyIds[fieldId];
                var fieldType = itemType.GetField(fieldName);
                if (fieldType != null)
                {
                    var value = DeserializeObject(reader, fieldType.FieldType);
                    fieldType.SetValue(o, value);
                }
                else
                {
                    var propType = itemType.GetProperty(fieldName);
                    //Deserialize the value
                    var value = DeserializeObject(reader, propType.PropertyType);
                    propType.SetValue(o, value, null);
                }
            }
        }

        /// <summary>
        ///   Serialize an object into an array of bytes
        /// </summary>
        /// <param name = "item">The object to serialize</param>
        /// <returns>A byte array representation of the item</returns>
        public static byte[] Serialize(object item)
        {
            CreateStacks();


            try
            {
                _ktStack.Push(_knownTypes);
                _piStack.Push(_propertyIds);
                _soStack.Push(_seenObjects);

                _propertyIds = new List<string>();
                _knownTypes = new List<Type>();
                _seenObjects = new Dictionary<object, int>();
                var strm = new MemoryStream();
                var wr = new BinaryWriter(strm);
                SerializeObject(item, wr, null);
                var outputStrm = new MemoryStream();
                var outputWr = new BinaryWriter(outputStrm);
                outputWr.Write("SerV1");
                outputWr.Write(_knownTypes.Count);
                foreach (var kt in _knownTypes)
                {
                    outputWr.Write(kt.AssemblyQualifiedName);
                }
                outputWr.Write(_propertyIds.Count);
                foreach (var pi in _propertyIds)
                {
                    outputWr.Write(pi);
                }
                strm.WriteTo(outputStrm);

                return outputStrm.ToArray();
            }
            finally
            {
                _knownTypes = _ktStack.Pop();
                _propertyIds = _piStack.Pop();
                _seenObjects = _soStack.Pop();
            }
        }

        private static void SerializeObject(object item, BinaryWriter writer, Type propertyType)
        {
            if (item == null)
            {
                writer.Write((ushort)0xFFFE);
                return;
            }
            var itemType = item.GetType();

            //If this isn't a simple type, then this might be a subclass so we need to
            //store the type
            if (propertyType != itemType)
            {
                //Write the type identifier
                var tpId = GetTypeId(itemType);
                writer.Write(tpId);
            }
            else
                //Write a dummy identifier
                writer.Write((ushort)0xFFFF);

            //Check for simple types again
            if (IsSimpleType(itemType))
            {
                if (itemType.IsEnum)
                    WriteValue(writer, (int)item);
                else
                    WriteValue(writer, item);
                return;
            }

            //Check whether this object has been seen
            if (_seenObjects.ContainsKey(item) && !item.GetType().IsValueType)
            {
                writer.Write('S');
                writer.Write(_seenObjects[item]);
                return;
            }

            //We are going to serialize an object
            writer.Write('O');
            if (!item.GetType().IsValueType)
                _seenObjects[item] = _seenObjects.Count;

            //Check for collection types)
            if (item is Array)
            {
                SerializeArray(item as Array, itemType, writer);
                return;
            }
            if (item is IDictionary)
            {
                SerializeDictionary(item as IDictionary, itemType, writer);
                return;
            }
            if (item is IList)
            {
                SerializeList(item as IList, itemType, writer);
                return;
            }

            if (item is Vector2)
            {
                SerializerVector2((Vector2)item, itemType, writer);
                return;
            }
            if (item is Vector3)
            {
                SerializerVector3((Vector3)item, itemType, writer);
                return;
            }
            if (item is Vector4)
            {
                SerializerVector4((Vector4)item, itemType, writer);
                return;
            }

            if (item is Color)
            {
                SerializerColor((Color)item, itemType, writer);
                return;
            }

            //Otherwise we are serializing an object
            SerializeObjectAndProperties(item, itemType, writer);
        }

        private static void SerializerColor(Color c, Type itemType, BinaryWriter writer)
        {
            writer.Write(c.R);
            writer.Write(c.G);
            writer.Write(c.B);
            writer.Write(c.A);
        }

        private static void SerializerVector2(Vector2 vector, Type itemType, BinaryWriter writer)
        {
            writer.Write(vector.X);
            writer.Write(vector.Y);
        }

        private static void SerializerVector3(Vector3 vector, Type itemType, BinaryWriter writer)
        {
            writer.Write(vector.X);
            writer.Write(vector.Y);
            writer.Write(vector.Z);
        }

        private static void SerializerVector4(Vector4 vector, Type itemType, BinaryWriter writer)
        {
            writer.Write(vector.X);
            writer.Write(vector.Y);
            writer.Write(vector.Z);
            writer.Write(vector.W);
        }

        private static void SerializeList(IList item, Type tp, BinaryWriter writer)
        {
            Type valueType = null;
            //Try to optimize the storage of types based on the type of list
            if (tp.IsGenericType)
            {
                var types = tp.GetGenericArguments();
                valueType = types[0];
            }

            writer.Write(item.Count);
            foreach (var val in item)
            {
                SerializeObject(val, writer, valueType);
            }
        }

        private static void SerializeDictionary(IDictionary item, Type tp, BinaryWriter writer)
        {
            Type keyType = null;
            Type valueType = null;
            //Try to optimise storage based on the type of dictionary
            if (tp.IsGenericType)
            {
                var types = tp.GetGenericArguments();
                keyType = types[0];
                valueType = types[1];
            }

            //Write out the size
            writer.Write(item.Count);
            //Serialize the pairs
            foreach (var key in item.Keys)
            {
                SerializeObject(key, writer, keyType);
            }
            foreach (var val in item.Values)
            {
                SerializeObject(val, writer, valueType);
            }
        }

        private static void SerializeArray(Array item, Type tp, BinaryWriter writer)
        {
            var length = item.Length;
            writer.Write(length);
            var propertyType = tp.GetElementType();
            //Special optimization for arrays of byte
            if (propertyType == typeof(byte))
                writer.Write((byte[])item, 0, length);
            //Special optimization for arrays of simple types
            //which don't need to have the entry type stored
            //for each item
            else if (IsSimpleType(propertyType))
                for (var l = 0; l < length; l++)
                {
                    WriteValue(writer, item.GetValue(l));
                }
            else
                for (var l = 0; l < length; l++)
                {
                    SerializeObject(item.GetValue(l), writer, propertyType);
                }
        }

        /// <summary>
        ///   Return whether the type specified is a simple type that can be serialized fast
        /// </summary>
        /// <param name = "tp">The type to check</param>
        /// <returns>True if the type is a simple one and can be serialized directly</returns>
        private static bool IsSimpleType(Type tp)
        {
            return tp.IsPrimitive || tp == typeof(DateTime) ||
                tp == typeof(string) || tp.IsEnum || tp == typeof(Guid);
        }

        private static void SerializeObjectAndProperties(object item, Type itemType, BinaryWriter writer)
        {
            lock (Vanilla)
            {
                if (Vanilla.ContainsKey(itemType) == false)
                    Vanilla[itemType] = Activator.CreateInstance(itemType);
            }


            WriteProperties(itemType, item, writer);
            WriteFields(itemType, item, writer);
        }

        private static void WriteProperties(Type itemType, object item, BinaryWriter writer)
        {
            var propertyStream = new MemoryStream();
            var pw = new BinaryWriter(propertyStream);
            byte propCount = 0;

            //Get the properties of the object
            var properties = GetPropertyInfo(itemType);
            foreach (var property in properties)
            {
                var value = property.GetValue(item, null);
                //Don't store null values
                if (value == null) continue;
                ////Don't store empty collections
                //if (value is ICollection)
                //    if ((value as ICollection).Count == 0) continue;
                ////Don't store empty arrays
                //if (value is Array)
                //    if ((value as Array).Length == 0) continue;
                //Check whether the value differs from the default
                //lock (Vanilla)
                //{
                //    if (value.Equals(property.GetValue(Vanilla[itemType], null))) continue;
                //}
                //If we get here then we need to store the property
                propCount++;
                pw.Write(GetPropertyDefinitionId(property.Name));
                SerializeObject(value, pw, property.PropertyType);
            }
            writer.Write(propCount);
            propertyStream.WriteTo(writer.BaseStream);
        }

        private static void WriteFields(Type itemType, object item, BinaryWriter writer)
        {
            var fieldStream = new MemoryStream();
            var fw = new BinaryWriter(fieldStream);
            byte fieldCount = 0;

            //Get the public fields of the object
            var fields = GetFieldInfo(itemType);
            foreach (var field in fields)
            {
                var value = field.GetValue(item);
                //Don't store null values
                if (value == null) continue;
                //Don't store empty collections
                //if (value is ICollection)
                //    if ((value as ICollection).Count == 0) continue;
                ////Don't store empty arrays
                //if (value is Array)
                //    if ((value as Array).Length == 0) continue;
                //Check whether the value differs from the default
                //lock (Vanilla)
                //{
                //    if (value.Equals(field.GetValue(Vanilla[itemType]))) continue;
                //}
                //if we get here then we need to store the field
                fieldCount++;
                fw.Write(GetPropertyDefinitionId(field.Name));
                SerializeObject(value, fw, field.FieldType);
            }
            writer.Write(fieldCount);
            fieldStream.WriteTo(writer.BaseStream);
        }

        /// <summary>
        ///   Write a basic untyped value
        /// </summary>
        /// <param name = "writer">The writer to commit byte to</param>
        /// <param name = "value">The value to write</param>
        private static void WriteValue(BinaryWriter writer, object value)
        {
            if (value is float)
                writer.Write((float)value);
            else if (value is string)
                writer.Write((string)value);
            else if (value is bool)
                writer.Write((bool)value
                                 ? 'Y'
                                 : 'N');
            else if (value is Guid)
                writer.Write(value.ToString());
            else if (value is DateTime)
                writer.Write(((DateTime)value).Ticks);
            else if (value is char)
                writer.Write((char)value);
            else if (value is ushort)
                writer.Write((ushort)value);
            else if (value is double)
                writer.Write((double)value);
            else if (value is ulong)
                writer.Write((ulong)value);
            else if (value is int)
                writer.Write((int)value);
            else if (value is uint)
                writer.Write((uint)value);
            else if (value is byte)
                writer.Write((byte)value);
            else if (value is long)
                writer.Write((long)value);
            else if (value is short)
                writer.Write((short)value);
            else if (value is sbyte)
                writer.Write((sbyte)value);
            else
                writer.Write((int)value);
        }

        /// <summary>
        ///   Read a basic value from the stream
        /// </summary>
        /// <param name = "reader">The reader with the stream</param>
        /// <param name = "tp">The type to read</param>
        /// <returns>The hydrated value</returns>
        private static object ReadValue(BinaryReader reader, Type tp)
        {
            if (tp == typeof(string))
                return reader.ReadString();
            if (tp == typeof(bool))
                return reader.ReadChar() == 'Y';
            if (tp == typeof(DateTime))
                return new DateTime(reader.ReadInt64());
            if (tp == typeof(float))
                return reader.ReadSingle();
            if (tp == typeof(char))
                return reader.ReadChar();
            if (tp == typeof(ushort))
                return reader.ReadUInt16();
            if (tp == typeof(double))
                return reader.ReadDouble();
            if (tp == typeof(ulong))
                return reader.ReadUInt64();
            if (tp == typeof(int))
                return reader.ReadInt32();
            if (tp == typeof(uint))
                return reader.ReadUInt32();
            if (tp == typeof(byte))
                return reader.ReadByte();
            if (tp == typeof(long))
                return reader.ReadInt64();
            if (tp == typeof(short))
                return reader.ReadInt16();
            if (tp == typeof(sbyte))
                return reader.ReadSByte();
            if (tp == typeof(Guid))
                return new Guid(reader.ReadString());
            return reader.ReadInt32();
        }

        /// <summary>
        ///   Logs a type and returns a unique token for it
        /// </summary>
        /// <param name = "tp">The type to retrieve a token for</param>
        /// <returns>A 2 byte token representing the type</returns>
        private static ushort GetTypeId(Type tp)
        {
            var tpId = _knownTypes.IndexOf(tp);

            if (tpId < 0)
            {
                tpId = _knownTypes.Count;
                _knownTypes.Add(tp);
                try
                {
                    lock (Vanilla)
                    {
                        if (!tp.IsArray && tp.IsValueType == false && tp != typeof(string)) Vanilla[tp] = Activator.CreateInstance(tp);
                    }
                }
                catch (Exception)
                {
                }
            }
            return (ushort)tpId;
        }
    }
}