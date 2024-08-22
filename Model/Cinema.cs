using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace TheMovie.Model
{
    public class Cinema (string name, int screen, PlayTimeRepository playTimes)
    {
        public string Name { get; set; } = name;
        public int Screen { get; set; } = screen;
        public PlayTimeRepository PlayTimes { get; set; } = playTimes;
    }
}
