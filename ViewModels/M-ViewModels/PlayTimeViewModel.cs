using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TheMovie.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TheMovie.ViewModels
{
    public class PlayTimeViewModel
    {
        public PlayTime PlayTime { get; }
        public DateTime? StartTime { get; set; }
        public string RunningTime { get; set; }
        public Movie Movie { get; set; }
        //public int? DurationPlus30 { get; set; }

        public PlayTimeViewModel(PlayTime playTime)
        {
            PlayTime = playTime;
            StartTime = playTime.StartTime;
            Movie = playTime.Movie;
            //DurationPlus30 = Movie.Duration + 30;
            RunningTime = StartTime?.ToString("dd/MM/yyyy HH:mm") + "-" + (StartTime + TimeSpan.FromMinutes(double.Parse(Movie.Duration.ToString()) + 30))?.ToString("HH:mm");
        }
    }
}
