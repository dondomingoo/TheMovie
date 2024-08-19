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
    public class MainViewModel : INotifyPropertyChanged
    {
        private MovieRepository mR = new();
        private MovieViewModel selectedMovie;
        public MovieViewModel SelectedMovie
        {
            get
            {
                return selectedMovie;
            }
            set
            {
                if (selectedMovie != value)
                {
                    selectedMovie = value;
                    OnPropertyChanged("SelectedMovie");
                }
            }
        }
        public ObservableCollection<MovieViewModel> MoviesVM { get; set; }
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public ICommand AddCommand { get; } = new AddCommand();
        public ICommand SaveCommand { get; } = new SaveCommand();
        public ICommand DeleteCommand { get; } = new DeleteCommand();

        public MainViewModel()
        {
            MoviesVM = [];
            foreach (Movie movie in mR.GetMovies())
            {
                MoviesVM.Add(new MovieViewModel(movie));
            }
        }

        public void AddMovie()
        {
            Movie movie = new(mR.CalculateMovieId(), "Titel", 0, "Genre");
            MovieViewModel mVM = new(movie);
            MoviesVM.Add(mVM);
            SelectedMovie = mVM;
        }

        public void DeleteMovie()
        {
            //mR.DeleteMovie(SelectedMovie.Movie);
            MoviesVM.Remove(SelectedMovie);
        }

        public void SaveMovies()
        {
            List<Movie> movieList = [];
            foreach (MovieViewModel movieViewModel in MoviesVM)
            {
                movieList.Add(movieViewModel.Movie);
            }
            mR.UpdateMovies(movieList);
            //bool b = false;
            //List<Movie> movies = mR.GetMovies();
            //for (int i = 0; i < movies.Count; i++)
            //{
            //    if (SelectedMovie.Movie.MovieId == movies[i].MovieId)
            //    {
            //        mR.UpdateMovies(SelectedMovie.Movie);
            //        b = true;
            //        break;
            //    }
            //}
            //if (b == false)
            //{
            //    mR.AddMovie(SelectedMovie.Movie);
            //}
        }
    }
}
