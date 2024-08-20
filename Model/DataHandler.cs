using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace TheMovie.Model
{
    internal class DataHandler
    {
        public static string[] LoadFromFile(string fileName)
        {
            if (!File.Exists(fileName))
            {
                using StreamWriter sw = new(fileName);
            }

            using StreamReader sr = new(fileName);
            string[] lines = sr.ReadToEnd().Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

            return lines;
        }
        public static void SaveDataFile<T>(List<T> entities, string fileName) where T : IEntity
        {
            try
            {
                using StreamWriter sw = new(fileName);
                foreach (IEntity entity in entities)
                {
                    sw.WriteLine(entity.ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }
    }
}
