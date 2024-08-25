using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMovie.Model;

namespace TheMovie.ViewModels
{
    public class ScreenViewModel
    {
        public Screen Screen { get; }
        public string CinemaName { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public PlayTimeRepository PlayTimes { get; set; }

        public ScreenViewModel(Screen screen) 
        {
            Screen = screen;
            CinemaName = screen.CinemaName;
            Name = screen.Name;
            Capacity = screen.Capacity;
            PlayTimes = screen.PlayTimes;
        }
    }
}
