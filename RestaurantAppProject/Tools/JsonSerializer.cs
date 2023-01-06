using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAppProject.Tools
{
    internal class JsonSerializer<T>
    {
        public static TypeNameHandling TypeNameHandling { get; private set; }

        public static void SaveData(List<T> list, string path)
        {
            CreateFileIfNotExist(path);

            if (!path.EndsWith(".json"))
            {
                Console.WriteLine("File should be json type");
                return;
            }
            JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All};
            string serialize = JsonConvert.SerializeObject(list, settings);

            File.WriteAllText(path, serialize);
        }

        async public static Task<List<T>> LoadData(string path)
        {
            List<T> list = new List<T>();
            if (!File.Exists(path)) return list;
            if (IsFileEmpty(path)) return list;
            if (!path.EndsWith(".json")) return list;

            var serialized = await File.ReadAllTextAsync(path);

            JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
            list = JsonConvert.DeserializeObject<List<T>>(serialized, settings);
            Console.WriteLine("Data loaded");

            return list;
        }

        private static void CreateFileIfNotExist(string path)
        {
            if (File.Exists(path))
            {
                try
                {
                    using (File.Create(path)) { };
                }

                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private static bool IsFileEmpty(string path)
        {
            FileInfo file = new FileInfo(path);
            if (file.Length > 2)
                return false;

            return true;
        }
    }
}
