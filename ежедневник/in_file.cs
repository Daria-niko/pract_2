using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ежедневник
{
    internal class in_file
    {

        public static void Serialize<T>(List<T> note) {
            string json = JsonConvert.SerializeObject(note);
            File.WriteAllText("C:\\Users\\Дарья\\source\\repos\\ежедневник\\Ежедневник.json", json);
        }

        public static List<T> Mydeserializer<T>()
        {
            string json = File.ReadAllText("C:\\Users\\Дарья\\source\\repos\\ежедневник\\Ежедневник.json");
            List<T> note = JsonConvert.DeserializeObject<List<T>>(json);
            return note;
        }
    }
}
