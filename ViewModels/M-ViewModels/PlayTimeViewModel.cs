using TheMovie.Models;

namespace TheMovie.ViewModels
{
    public class PlayTimeViewModel
    {
        public PlayTime PlayTime { get; set; }
        public DateTime? StartTime { get; set; }
        public string RunningTime { get; set; }
        public Movie Movie { get; set; }

        public PlayTimeViewModel(PlayTime playTime)
        {
            PlayTime = playTime;
            StartTime = playTime.StartTime;
            Movie = playTime.Movie;
            RunningTime = $"{StartTime?.ToString("dd/MM/yyyy HH:mm")}-{(StartTime + TimeSpan.FromMinutes(double.Parse(Movie.Duration.ToString()) + 30))?.ToString("HH:mm")}";
        }
    }
}
