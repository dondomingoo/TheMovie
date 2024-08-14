using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMovie.ViewModels
{
    public class MovieVM
    {
        public Movie Movie { get; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public string Genre { get; set; }

        public MovieVM(Movie Movie)
        {
            this.Movie = Movie;
            Name = Movie.Name;
            Duration = Movie.Duration;
            Genre = Movie.Genre;
        }

    }
}
