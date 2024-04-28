using Newtonsoft.Json;
using System.IO;

namespace Будни_Программиста.Model
{
    internal class Files
    {
        public static void Serialize<T>(T type, string path)
        {
            string json = JsonConvert.SerializeObject(type);
            File.WriteAllText(path, json);
        }
        public static T Deserialize<T>(string path)
        {
            string json = File.ReadAllText(path);
            T type = JsonConvert.DeserializeObject<T>(json);
            return type;
        }
    }
}
