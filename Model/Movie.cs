using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMovie.Model
{
    internal class Movie
    {
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
        public string Genre { get; set; }

        public Movie(string name, TimeSpan duration, string genre)
        {
            Name = name;
            Duration = duration;
            Genre = genre;
        }
    }
}
