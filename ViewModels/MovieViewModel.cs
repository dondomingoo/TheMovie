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
        public Movie Movie { get; }
        public string Title { get; set; }
        public int? Duration
        {
            get { return duration; }
            set { duration = value; }
        }
        public string Genre { get; set; }

        public MovieViewModel(Movie Movie)
        {
            this.Movie = Movie;
            Title = Movie.Title;
            Duration = Movie.Duration;
            Genre = Movie.Genre;
        }

    }
}
