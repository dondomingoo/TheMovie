using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public int Seats { get; set; }
        public int ReservedSeats { get; set; }
        public int AvailableSeats => Seats - ReservedSeats; // AvailableSeats property som returnerer antal sæder minus antal bookinger.
        public ReadOnlyObservableCollection<Reservation> Reservations { get; set; }
    }
}
