using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

// credited to http://stackoverflow.com/questions/6115721/how-to-save-restore-serializable-object-to-from-file
namespace TLog.Manager
{
    class Serialization
    {

    
        public static byte[] ObjectAsBytes<T>(T objectToWrite)
        {
            byte[] bytes;
            var formatter = new BinaryFormatter();
            using (MemoryStream stream = new MemoryStream())
            {
                formatter.Serialize(stream, objectToWrite);
                bytes = stream.ToArray();
            }

            return bytes;
        }

        public static T BytesAsObject<T>(byte[] objectToRead)
        {
            BinaryFormatter bf = new BinaryFormatter();
            var obj = bf.Deserialize(new MemoryStream(objectToRead));
            return (T)obj;
        }
     /// <summary>
     /// Writes the given object instance to a binary file.
     /// <para>Object type (and all child types) must be decorated with the [Serializable] attribute.</para>
     /// <para>To prevent a variable from being serialized, decorate it with the [NonSerialized] attribute; cannot be applied to properties.</para>
     /// </summary>
     /// <typeparam name="T">The type of object being written to the XML file.</typeparam>
     /// <param name="filePath">The file path to write the object instance to.</param>
     /// <param name="objectToWrite">The object instance to write to the XML file.</param>
     /// <param name="append">If false the file will be overwritten if it already exists. If true the contents will be appended to the file.</param>
        public static void WriteToBinaryFile<T>(string filePath, T objectToWrite, bool append = false)
        {
            using (Stream stream = File.Open(filePath, append ? FileMode.Append : FileMode.Create))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, objectToWrite);
            }
        }

        /// <summary>
        /// Reads an object instance from a binary file.
        /// </summary>
        /// <typeparam name="T">The type of object to read from the XML.</typeparam>
        /// <param name="filePath">The file path to read the object instance from.</param>
        /// <returns>Returns a new instance of the object read from the binary file.</returns>
        public static T ReadFromBinaryFile<T>(string filePath)
        {
            using (Stream stream = File.Open(filePath, FileMode.Open))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                return (T)binaryFormatter.Deserialize(stream);
            }
        }
    }
}
