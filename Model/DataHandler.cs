﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
        public static void SaveDataFile<T>(string headers, List<T> entities, string fileName) where T : IEntity
        {
            try
            {
                using StreamWriter sw = new(fileName, false, Encoding.UTF8);
                sw.WriteLine(headers);
                foreach (IEntity entity in entities)
                {
                    sw.WriteLine(entity.ToString());
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"An error occurred: {e.GetType().Name} - {e.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
