namespace TheMovie.Models
{
    public class PlayTime(DateTime? startTime, Movie movie): IEntity
    {
        public DateTime? StartTime { get; set; } = startTime;
        public Movie Movie { get; set; } = movie;

        public override string ToString()
        {
            return $"{StartTime};{(StartTime + TimeSpan.FromMinutes(double.Parse(Movie.Duration.ToString()) + 15))?.ToString("HH:mm")};{Movie.Title};{Movie.MovieId}";
        }
    }
}
