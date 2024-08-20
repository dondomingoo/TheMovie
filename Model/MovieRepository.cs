using System.IO;
using System.Windows;
using TheMovie.Model;

public class MovieRepository
{
    //En ny liste som inneholder Movie-objekter blir opprettet
    public List<Movie> movies = new List<Movie>();
    private string fileName;

    //Konstruktør som kaller på LoadFromFile metoden for at listen skal fylles med Movie-objekter fra filen
    public MovieRepository(string fileName = "MovieDoc.csv")
    {
        this.fileName = fileName;
        LoadMovies();
    }

    //Metode som ligger et Movie-objekt til listen og kaller på SaveToFile metoden for at lagre listen til filen
    public void AddMovie(Movie movie)
    {
        movies.Add(movie);
        SaveMovies();
    }

    //Metode som oppdaterer listen med Movie-objekter og kalder på SaveToFile metoden for at lagre listen til filen
    public void Update(List<Movie> updatedMovies)
    {
        movies = updatedMovies;
        SaveMovies();
    }

    //Metode som fyller listen med Movie-objekter fra filen MovieDoc.txt
    public void LoadMovies()
    {
        string[] lines = DataHandler.LoadFromFile(fileName);
        for (int i = 0; i < lines.Length - 1; i++)
        {
            string[] attributes = lines[i].Split(';');
            movies.Add(new Movie(attributes[0], int.Parse(attributes[1]), attributes[2]));
        }
    }
    public void SaveMovies()
    {
        DataHandler.SaveDataFile(movies, fileName);
    }
}
