namespace TheMovie.Models
{
    public class PlayTime: IEntity
    {
        public int ScreenNumber { get; set; }
        public int ScreenCapacity { get; set; }
        public int RemainingTickets { get; set; }
        public DateTime? StartTime { get; set; }
        public Movie Movie { get; set; }
        public Cinema Cinema { get; set; }
        public ReservationRepository ResRepository { get; set; }

        public override string ToString()
        {
            return $"{StartTime};{(StartTime + TimeSpan.FromMinutes(double.Parse(Movie.Duration.ToString()) + 15))?.ToString("HH:mm")};{Movie.Title};{Movie.Genre};{Movie.Director};{Movie.PremiereDate};{Movie.MovieId};{ScreenNumber}";
        }

        public PlayTime(DateTime? startTime, Movie movie, string screenName, int screenCapacity, Cinema cinema)
        {
            ScreenNumber = int.Parse(new string(screenName.Where(char.IsDigit).ToArray()));
            ScreenCapacity = screenCapacity;
            ResRepository = new ReservationRepository(cinema);
            StartTime = startTime;
            Movie = movie;
            Cinema = cinema;

        }
    }
}
