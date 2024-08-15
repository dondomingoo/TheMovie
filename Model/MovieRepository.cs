using System.IO;
using System.Windows;
using TheMovie.Model;

public class MovieRepository
{
    public List<Movie> movies = new List<Movie>();

    public MovieRepository()
    {
        LoadFromFile(movies);
    }

    public void AddMovie(Movie movie)
    {
        movies.Add(movie);
        SaveToFile();
    }

    public List<Movie> GetMovies()
    {
        return new List<Movie>(movies);
    }

    public void Update(List<Movie> updatedMovies)
    {
        movies = updatedMovies;
        SaveToFile();
    }

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
                movies.Add(new Movie(attributes[0], int.Parse(attributes[1]), attributes[2]));
            }
        
       
    }

    public void SaveToFile()
    {
        using (StreamWriter writer = new("MovieDoc.txt"))
        {
            foreach (Movie movie in movies)
            {
                writer.WriteLine($"{movie.Title},{movie.Duration},{movie.Genre}");
            }
        }
    }
}
