using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TheMovie.Model
{
    public class PlayTime : INotifyPropertyChanged
    {
        public Movie Movie { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime => StartTime.Add(Movie.Duration).AddMinutes(30); // EndTime property som returnerer StartTime + Duration + 30 minutter.
        public string Screen { get; set; }
        //public int Seats { get; set; }
        //public int ReservedSeats { get; set; }
        private int _seats;
        public int Seats
        {
            get => _seats;
            set
            {
                if (_seats != value)
                {
                    _seats = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(AvailableSeats)); // Notify that AvailableSeats has also changed
                }
            }
        }

        private int _reservedSeats;


        public int ReservedSeats
        {
            get => _reservedSeats;
            set
            {
                if (_reservedSeats != value)
                {
                    _reservedSeats = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(AvailableSeats)); // Notify that AvailableSeats has also changed
                }
            }
        }

        public int AvailableSeats => Seats - ReservedSeats; // AvailableSeats property som returnerer antal sæder minus antal bookinger.
        public ReadOnlyObservableCollection<Reservation> Reservations { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
