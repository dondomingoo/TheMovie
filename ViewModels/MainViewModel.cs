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
        private MovieRepository movieRepository; //Repository som indeholder en liste af film

        private MovieViewModel _selectedMovie; //Den valgte film i viewet 


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

        public ICommand AddCommand { get; set; } //Kommando til at tilføje en ny film til listen af film
        public ICommand SaveCommand { get; set; } //Kommando til at gemme listen af film til en fil

        //MainViewModel constructor som initialiserer en ny instans af MovieRepository og MovieViewModels
        public MainViewModel()
        {
            movieRepository = new MovieRepository();
            movieViewModels = new ObservableCollection<MovieViewModel>();
            LoadMoviesFromRepository();


            AddCommand = new AddCommand();
            SaveCommand = new SaveCommand();
        }

        //Metode til at indlæse film fra repository til viewmodel
        private void LoadMoviesFromRepository()
        {
            foreach (Movie movie in movieRepository.movies)
            {
                movieViewModels.Add(new MovieViewModel(movie));
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
            movieRepository.SaveMovies();
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
        
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
