using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMovie.Model
{
    public class Cinema
    {
        public string Name { get; set; }
        public ObservableCollection<PlayTime> PlayTimes { get; set; }
        
    }
    //public class Cinema som indeholder en liste af PlayTime objekter og et navn.
}
