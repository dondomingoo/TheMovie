using System.IO;
using System.Windows;
using TheMovie.Model;

public class MovieRepository
{
    private List<Movie> movies = [];
    private string fileName;

    public MovieRepository(string fileName = "MovieDoc.csv")
    {
        this.fileName = fileName;
        LoadFromFile();
    }
    //public void AddMovie(Movie movie)
    //{
    //    movies.Add(movie);
    //    SaveToFile();
    //}
    public List<Movie> GetMovies()
    {
        return movies;
    }
    public void UpdateMovies(List<Movie> movieList)
    {
        //for (int i = 0; i < movies.Count; i++)
        //{
        //    if (movies[i].MovieId == movie.MovieId)
        //    {
        //        movies[i] = movie;
        //    }
        //}
        movies = movieList;
        SaveToFile();
    }
    //public void DeleteMovie(Movie movie)
    //{
    //    for (int i = 0; i < movies.Count; i++)
    //    {
    //        if (movies[i].MovieId == movie.MovieId)
    //        {
    //            movies.Remove(movies[i]);
    //        }
    //    }
    //    //SaveToFile();
    //}
    //public int CalculateMovieId()
    //{
    //    List<int> ids = new List<int>();
    //    foreach (Movie movie in movies)
    //    {
    //        ids.Add(movie.MovieId);
    //    }
    //    for (int i = 1; i <= ids.Count; i++)
    //    {
    //        if (!ids.Contains(i))
    //        {
    //            return i;
    //        }
    //    }
    //    return ids.Count + 1;
    //}
    public void LoadFromFile()
    {
        if (!File.Exists(fileName))
        {
            using StreamWriter sw = new(fileName);
        }

        using StreamReader sr = new(fileName);
        string[] lines = sr.ReadToEnd().Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

        for (int i = 0; i < lines.Length - 1; i++)
        {
            string[] attributes = lines[i].Split(';');
            movies.Add(new Movie(attributes[0], int.Parse(attributes[1]), attributes[2]));
        }
    }
    public void SaveToFile()
    {
        try
        {
            using (StreamWriter writer = new(fileName))
            {
                foreach (Movie movie in movies)
                {
                    writer.WriteLine($"{movie.Title};{movie.Duration};{movie.Genre}");
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
    }
}
