using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAppProject.Tools
{
    public static class FileOperation
    {
        public static void CreateFileIfNotExist(string path)
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

        public static bool IsFileEmpty(string path)
        {
            FileInfo file = new FileInfo(path);
            if (file.Length > 2)
                return false;

            return true;
        }
    }
}
