using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMovie.Model
{
    public class Movie
    {
        public string Title { get; set; }
        public int DurationInMinutes { get; set; }
        public string Genre { get; set; }
        public TimeSpan Duration => TimeSpan.FromMinutes(DurationInMinutes); // Duration property som returnerer DurationInMinutes i TimeSpan format.
        public string Director { get; set; }
        public DateTime PremiereDate { get; set; }

        public Movie(string title, int duration, string genre, string director, DateTime premiereDate)
        {
            Title = title;
            DurationInMinutes = duration;
            Genre = genre;
            Director = director;
            PremiereDate = premiereDate;
        }
        public Movie()
        {
           
        }
        //Movie class som indeholder properties og en constructor som tager imod de nødvendige parametre for at oprette et Movie objekt.
        //en constructor uden parametre er også oprettet til at kunne oprette et Movie objekt uden at skulle angive parametre.
    }
}
