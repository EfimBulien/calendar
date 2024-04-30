using Newtonsoft.Json;
using System.IO;

namespace Будни_Программиста.Model
{
    internal static class Files
    {
        public static void Serialize<T>(T type, string path)
        {
            var json = JsonConvert.SerializeObject(type);
            File.WriteAllText(path, json);
        }
        public static T? Deserialize<T>(string path)
        {
            var json = File.ReadAllText(path);
            var type = JsonConvert.DeserializeObject<T>(json);
            return type;
        }
    }
}
