using System.IO;
using System.Text;
using System.Windows;
using TheMovie.Models;

namespace TheMovie.MVVM
{
    public class DataHandler
    {
        public static string[] LoadFromFile(string fileName)
        {
            try
            {
                if (!File.Exists(fileName))
                {
                    using StreamWriter sw = new(fileName);
                }
                using StreamReader sr = new(fileName);
                string[] lines = sr.ReadToEnd().Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                return lines;
            }
            catch (Exception e)
            {
                MessageBox.Show($"An error occurred: {e.GetType().Name} - {e.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                throw;
            }
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
