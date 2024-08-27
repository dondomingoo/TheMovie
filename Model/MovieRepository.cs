using System.IO;
using System.Windows;
using TheMovie.Model;

public class MovieRepository
{
    //En ny liste som inneholder Movie-objekter blir opprettet
    public List<Movie> movies = new List<Movie>();
    private Datahandler datahandler = new Datahandler();

    //Konstruktør som kaller på LoadFromFile metoden for at listen skal fylles med Movie-objekter fra filen
    public MovieRepository()
    {
        datahandler.LoadFromFile(movies);
    }

    //Metode som ligger et Movie-objekt til listen og kaller på SaveToFile metoden for at lagre listen til filen
    public void AddMovie(Movie movie)
    {
        movies.Add(movie);
        SaveMovie();
    }

    //Metode som oppdaterer listen med Movie-objekter og kalder på SaveToFile metoden for at lagre listen til filen
    public void Update(List<Movie> updatedMovies)
    {
        movies = updatedMovies;
        SaveMovie();
    }
    
    public void SaveMovie()
    {
        datahandler.SaveToFile(this);
    }

}
