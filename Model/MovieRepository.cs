using System.IO;
using System.Windows;
using TheMovie.Model;


namespace TheMovie.Model
{
    public class MovieRepository
    {
        public List<Movie> movies = new List<Movie>();

    //Konstruktør som kaller på LoadFromFile metoden for at listen skal fylles med Movie-objekter fra filen
    public MovieRepository()
    {
        _datahandler.LoadFromFile(movies);
    }

    //Metode som ligger et Movie-objekt til listen og kaller på SaveToFile metoden for at lagre listen til filen
    public void AddMovie(Movie movie)
    {
        movies.Add(movie);
        SaveMovie();
    }




        //Metode til at hente film fra hdd
        public void LoadFromFile()
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filePath = Path.Combine(docPath, "MovieDoc.txt");

            if (!File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    while (!reader.EndOfStream)
                    {
                        string title = reader.ReadLine()?.Replace("Titel: ", "");
                        int duration = int.Parse(reader.ReadLine()?.Replace("Varighed: ", ""));
                        string genre = reader.ReadLine()?.Replace("Genre: ", "");

                        reader.ReadLine();

                        Movie movie = new Movie()
                        {
                            Title = title,
                            Duration = duration,
                            Genre = genre
                        };

                        movies.Add(movie);
                    }
                }
            }

        }




        //Metode til at gemme film til hdd
        public void SaveToFile()
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            Console.WriteLine("Indtast filmtitel: ");
            string title = Console.ReadLine();

            Console.WriteLine("Indtast varighed: ");
            int duration = int.Parse(Console.ReadLine());

            Console.WriteLine("Indtast genre: ");
            string genre = Console.ReadLine();

            Movie movie = new Movie()
            {
                Title = title,
                Duration = duration,
                Genre = genre
            };

            using (StreamWriter writer = new StreamWriter(Path.Combine(docPath, "MovieDoc.txt"), true))
            {
                writer.WriteLine($"Titel: {movie.Title}");
                writer.WriteLine($"Varighed: {movie.Duration}");
                writer.WriteLine($"Genre: {movie.Genre}");
            }

        }

}
