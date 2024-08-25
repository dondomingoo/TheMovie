using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMovie.Model
{
    public class Screen(string cinemaName, string screenname, int capacity)
    {
        public string CinemaName { get; } = cinemaName;
        public string Name { get; } = screenname;
        public int Capacity { get; } = capacity;
        public PlayTimeRepository PlayTimes { get; } = new(cinemaName, screenname);
    }
}
