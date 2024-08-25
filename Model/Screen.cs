using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMovie.Model
{
    public class Screen
    {
        public string CinemaName {  get; set; }
        public string Name { get; set; }
        public int Capacity {  get; set; }
        public PlayTimeRepository PlayTimes { get; set; }
    
    public Screen (string cinemaName, string screenname, int capacity)
        {
            CinemaName = cinemaName;
            Name = screenname;
            Capacity = capacity;
            PlayTimes = new(cinemaName, screenname);
        }
    }
}
