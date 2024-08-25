using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMovie.Model;

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

        public MovieViewModel(Movie movie)
        {
            Movie = movie;
            Title = movie.Title;
            Duration = movie.Duration;
            Genre = movie.Genre;
            if (Duration.HasValue)
            {
                TimeSpan timeSpan = TimeSpan.FromMinutes(Duration.Value);
                Dur = $"{timeSpan.Hours} timer og {timeSpan.Minutes} minutter";
            }
        }
    }
}
