using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMovie.Model
{
    public class Datahandler
    {
        public void LoadFromFile(List<Movie> movies)
        {
            if (!File.Exists("MovieDoc.txt"))
            {
                using StreamWriter sw = new("MovieDoc.txt");
            }

            using StreamReader sr = new("MovieDoc.txt");
            string[] lines = sr.ReadToEnd().Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            for (int i = 0; i < lines.Length - 1; i++)
            {
                string[] attributes = lines[i].Split(',');
                movies.Add(new Movie(attributes[0], int.Parse(attributes[1]), attributes[2], attributes[3], DateTime.Parse(attributes[4])));
            }
        }

        //Metode som lagrer listen med Movie-objekter til filen MovieDoc.txt
        public void SaveToFile(MovieRepository movieRepository)
        {
            using (StreamWriter writer = new("MovieDoc.txt"))
            {
                foreach (Movie movie in movieRepository.movies)
                {
                    writer.WriteLine($"{movie.Title},{movie.DurationInMinutes},{movie.Genre},{movie.Director},{movie.PremiereDate:yyyy-MM-dd}");
                }
            }
        }
    }
}
