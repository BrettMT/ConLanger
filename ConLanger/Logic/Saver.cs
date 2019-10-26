using ConLanger.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConLanger.Logic
{
    class Saver
    {
        public void SerializeLanguageToText(Language language, string fileName)
        {
            JsonSerializer serializer = new JsonSerializer();

            using (StreamWriter sw = File.CreateText($@"{fileName}.txt"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, language);
            }
        }

        public Language DeSerializeLanguageFromText(string fileName)
        {
            JsonSerializer serializer = new JsonSerializer();
            Language l;

            using (StreamReader sr = new StreamReader($@"{fileName}.txt"))
                using (JsonReader reader = new JsonTextReader(sr))
            {
                l = (Language)serializer.Deserialize(reader, typeof(Language));
            }

            return l;
        }
    }
}
