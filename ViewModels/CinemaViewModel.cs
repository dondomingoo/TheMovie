using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TheMovie.Commands;
using TheMovie.Model;

namespace TheMovie.ViewModels
{
    public class CinemaViewModel : INotifyPropertyChanged
    {
        private CinemaRepository _cinemaRepository = new CinemaRepository();
        public Cinema Cinema;
        public string Name => Cinema.Name; // Navn property som returnerer Cinema.Name og bruges til at binde til viewet.
        public ObservableCollection<PlayTime> PlayTimes => Cinema.PlayTimes; // PlayTimes property som returnerer Cinema.PlayTimes og bruges til at binde til viewet.


        

        //Constructor som tager en Cinema som parameter og initialiserer Cinema property.
        public CinemaViewModel(Cinema cinema)
        {
            Cinema = cinema;
            

            if (Cinema.PlayTimes == null)
            {
                Cinema.PlayTimes = new ObservableCollection<PlayTime>();
            }
        }

        //Playtimes property som returnerer Cinema.PlayTimes og bruges til at binde til viewet.
        public ObservableCollection<PlayTime> Playtimes
        {
            get { return Cinema.PlayTimes; }
            set
            {
                if (Cinema.PlayTimes != value)
                {
                    Cinema.PlayTimes = value;
                    OnPropertyChanged();
                }
            }
        }


        //AddToSchedule metoden tager en PlayTime som parameter og tilføjer den til Cinema.PlayTimes og kalder OnPropertyChanged metoden.
        public void SaveSchedule()
        {
            _cinemaRepository.SaveCinemaSchedule(Cinema);
        }

        //LoadSchedule metoden tjekker om der findes en fil med Cinema.Name_Schedule.xlsx og kalder LoadScheduleFromFile metoden hvis filen eksisterer.
        public void LoadSchedule()
        {
            _cinemaRepository.LoadCinemaSchedule(Cinema);
            OnPropertyChanged(nameof(PlayTimes));
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
