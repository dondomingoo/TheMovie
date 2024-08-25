using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMovie.Model
{
    public class PlayTime
    {
        public Movie Movie { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime => StartTime.Add(Movie.Duration).AddMinutes(30); // EndTime property som returnerer StartTime + Duration + 30 minutter.
        public DateTime Date { get; set; }
        public string Screen { get; set; }

    }
}
