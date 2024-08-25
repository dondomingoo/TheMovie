using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace TheMovie.Model
{
    public class Cinema
    {
        public string Name { get; set; }
        public ScreenRepository Screens { get; set; }
        public List<int> ScreenCapacities { get; set; }


        public Cinema(string name, List<int> capacities) 
        {
            Name = name;
            ScreenCapacities = capacities;
            Screens = new(name, capacities);
        }
    }
}
