using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TheMovie.Model;

namespace TheMovie.ViewModels
{
    public class MovieViewModel : INotifyPropertyChanged
    {

        //Movie property som holder styr på hvilken film der er valgt i viewet og disse properties er bundet til viewet i form af tekstbokse og bliver opdateret når der sker ændringer i viewet.
        public Movie Movie;
        public string Title
        {
            get => Movie.Title;
            set
            {
                Movie.Title = value;
                OnPropertyChanged();
            }
        }
        public int Duration
        {
            get => Movie.Duration;
            set
            {
                Movie.Duration = value;
                OnPropertyChanged();
            }
        }
        public string Genre
        {
            get => Movie.Genre;
            set
            {
                Movie.Genre = value;
                OnPropertyChanged();
            }
        }

        //MovieViewModel constructor som initialiserer en ny instans af Movie og sætter de forskellige properties til at være lig med de properties der er i Movie klassen 
        public MovieViewModel(Movie Movie)
        {
            this.Movie = Movie;
         
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
