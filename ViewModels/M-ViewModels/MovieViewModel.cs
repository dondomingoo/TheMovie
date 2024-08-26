using TheMovie.Models;

namespace TheMovie.ViewModels
{
    public class MovieViewModel
    {
        private int? duration;
        public Movie Movie { get; set; }
        public string Title { get; set; }
        public int? Duration
        {
            get { return duration; }
            set { duration = value; }
        }
        public string Genre { get; set; }
        public string? Dur { get; set; }
        public string Director { get; set; }
        public DateTime? PremiereDate { get; set; }

        public MovieViewModel(Movie movie)
        {
            Movie = movie;
            Title = movie.Title;
            Duration = movie.Duration;
            Genre = movie.Genre;
            Director = movie.Director;
            PremiereDate = movie.PremiereDate;
            if (Duration.HasValue)
            {
                TimeSpan timeSpan = TimeSpan.FromMinutes(Duration.Value);
                Dur = $"{timeSpan.Hours} timer og {timeSpan.Minutes} minutter";
            }
        }
    }
}
