﻿using Newtonsoft.Json;
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
            FileOperation.CreateFileIfNotExist(path);

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
            if (FileOperation.IsFileEmpty(path)) return list;
            if (!path.EndsWith(".json")) return list;

            var serialized = await File.ReadAllTextAsync(path);

            JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
            list = JsonConvert.DeserializeObject<List<T>>(serialized, settings);
            Console.WriteLine("Data loaded");

            return list;
        }
    }
}
