using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace ContactBook
{
    class xmlAssist
    {
        public static SaveFile Load(string fileName) {
            XmlSerializer serializer = new XmlSerializer(typeof(SaveFile));
            TextReader reader = new StreamReader(fileName);
            SaveFile obj = (SaveFile)serializer.Deserialize(reader);
            reader.Close();
            return obj;
        }
        public static void Save<T>(T obj, string fileName) {
            TextWriter writer = new StreamWriter(fileName);
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            serializer.Serialize(writer, obj);
            writer.Close();
        }


    }
}
