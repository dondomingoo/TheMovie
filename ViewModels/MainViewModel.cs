using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TheMovie.Commands;
using TheMovie.Model;

namespace TheMovie.ViewModels
{
    public class MainViewModel:INotifyPropertyChanged
    {
        public ObservableCollection<MovieViewModel> movieViewModels { get; set; }  //Liste af MovieViewModels som er en liste af film der kan vises i viewet
        public ObservableCollection<CinemaViewModel> Cinemas { get; set; } //Liste af CinemaViewModels som er en liste af biografer der kan vises i viewet

        
        private MovieRepository movieRepository; //Repository som indeholder en liste af film
        private CinemaRepository cinemaRepository; //Repository som indeholder en liste af biografer

        private MovieViewModel _selectedMovie; //Den valgte film i viewet 
        private CinemaViewModel _selectedCinema; //Den valgte biograf i viewet
        private PlayTime _selectedPlayTime; //Den valgte spilletid i viewet
        private DateTime _selectedDate; //Den valgte dato i viewet
        private DateTime _selectedTime; //Den valgte tid i viewet
        private string _selectedScreen; //Den valgte sal i viewet
        private int _SelectedSeats; //Den valgte antal sæder i viewet




        //SelectedMovie property som holder styr på hvilken film der er valgt i viewet 
        public MovieViewModel SelectedMovie
        {
            get { return _selectedMovie; }
            set
            {
                _selectedMovie = value;
                OnPropertyChanged(nameof(SelectedMovie));
            }
        }

        //SelectedCinema property som holder styr på hvilken biograf der er valgt i viewet
        public CinemaViewModel SelectedCinema
        {
            get { return _selectedCinema; }
            set
            {
                _selectedCinema = value;
                OnPropertyChanged(nameof(SelectedCinema));
                if (_selectedCinema != null)
                {
                    _selectedCinema.LoadSchedule();
                }
            }
        }

        //SelectedPlayTime property som holder styr på hvilken spilletid der er valgt i viewet
        public PlayTime SelectedPlayTime
        {
            get { return _selectedPlayTime; }
            set
            {
                _selectedPlayTime = value;
                OnPropertyChanged(nameof(SelectedPlayTime));
            }
        }

        //SelectedDate property som holder styr på hvilken dato der er valgt i viewet
        public DateTime SelectedDate
        {
            get { return _selectedDate; }
            set
            {
                _selectedDate = value;
                OnPropertyChanged(nameof(SelectedDate));
            }
        }

        //SelectedTime property som holder styr på hvilken tid der er valgt i viewet
        public DateTime SelectedTime
        {
            get { return _selectedTime; }
            set
            {
                _selectedTime = value;
                OnPropertyChanged(nameof(SelectedTime));
            }
            
        }

        //SelectedScreen property som holder styr på hvilken sal der er valgt i viewet
        public string SelectedScreen
        {
            get { return _selectedScreen; }
            set
            {
                _selectedScreen = value;
                OnPropertyChanged(nameof(SelectedScreen));
            }
        }

        public int SelectedSeats
        {
            get { return _SelectedSeats; }
            set
            {
                _SelectedSeats = value;
                OnPropertyChanged(nameof(SelectedSeats));
            }
        }



        public ICommand AddCommand { get; set; } //Kommando til at tilføje en ny film til listen af film
        public ICommand SaveCommand { get; set; } //Kommando til at gemme listen af film til en fi
        public ICommand AddToScheduleCommand { get; set; } //Kommando til at tilføje en ny spilletid til listen af spilletider
        public ICommand SaveScheduleCommand { get; set; }//Kommando til at gemme listen af spilletider til en fil

        //MainViewModel constructor som initialiserer en ny instans af MovieRepository, MovieViewModels og CinemaViewModels og initialiserer AddCommand og SaveCommand kommandoerne
        //og sætter SelectedTime til at være lig med DateTime.Now og SelectedScreen til at være lig med "1"
        public MainViewModel()
        {
            movieRepository = new MovieRepository();
            cinemaRepository = new CinemaRepository();
            movieViewModels = new ObservableCollection<MovieViewModel>();
            Cinemas = new ObservableCollection<CinemaViewModel>();

            

            LoadMoviesFromRepository();
            LoadCinemasFromRepository();


            AddCommand = new AddCommand();
            SaveCommand = new SaveCommand();
            AddToScheduleCommand = new AddToScheduleCommand();
            SaveScheduleCommand = new SaveScheduleCommand();

            SelectedTime = DateTime.Now;
            SelectedScreen = "1";
            SelectedSeats = 50;

        }
        


    //Metode til at indlæse film fra repository til viewmodel
    private void LoadMoviesFromRepository()
        {
            foreach (Movie movie in movieRepository.movies)
            {
                movieViewModels.Add(new MovieViewModel(movie));
            }
        }

        //Metode til at indlæse biografer fra repository til viewmodel
        private void LoadCinemasFromRepository()
        {
            foreach (var cinema in cinemaRepository.GetCinemas())
            {
                Cinemas.Add(new CinemaViewModel(cinema));
            }
        }

            //Metode der kalder på AddMovie metoden i repository for at tilføje en ny film til listen af film og opdatere viewet
            public void AddMovie (Movie movie)
        {
            movieRepository.AddMovie(movie);
            movieViewModels.Add(new MovieViewModel(movie));
            UpdateMovieList();
        }

        //Metode der kalder på SaveToFile metoden i repository for at gemme listen af film til filen
        public void SaveMovie()
        {
            UpdateMovieList();
            movieRepository.SaveToFile();
        }

        //Metode der kalder på Update metoden i repository for at opdatere listen af film
        public void UpdateMovieList()
        {
            List<Movie> movieList = new List<Movie>();
            foreach (MovieViewModel movieViewModel in movieViewModels)
            {
                movieList.Add(movieViewModel.Movie);
            }
            movieRepository.Update(movieList);
        }

        //Metode der kalder på SaveSchedule metoden i CinemaViewModel for at gemme listen af spilletider til en fil
        public void SaveToSchedule()
        {
            if (SelectedCinema != null)
            {
                SelectedCinema.SaveSchedule();
            }
        }





        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
