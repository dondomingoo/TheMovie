using System.IO;
using System.Windows;
using TheMovie.Model;

public class MovieRepository
{
    //En ny liste som inneholder Movie-objekter blir opprettet
    public List<Movie> movies = new List<Movie>();

    //Konstruktør som kaller på LoadFromFile metoden for at listen skal fylles med Movie-objekter fra filen
    public MovieRepository()
    {
        LoadFromFile(movies);
    }

    //Metode som ligger et Movie-objekt til listen og kaller på SaveToFile metoden for at lagre listen til filen
    public void AddMovie(Movie movie)
    {
        movies.Add(movie);
        SaveToFile();
    }

    //Metode som oppdaterer listen med Movie-objekter og kalder på SaveToFile metoden for at lagre listen til filen
    public void Update(List<Movie> updatedMovies)
    {
        movies = updatedMovies;
        SaveToFile();
    }

    //Metode som fyller listen med Movie-objekter fra filen MovieDoc.txt
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
    public void SaveToFile()
    {
        using (StreamWriter writer = new("MovieDoc.txt"))
        {
            foreach (Movie movie in movies)
            {
                writer.WriteLine($"{movie.Title},{movie.DurationInMinutes},{movie.Genre},{movie.Director},{movie.PremiereDate:yyyy-MM-dd}");
            }
        }
    }
}
