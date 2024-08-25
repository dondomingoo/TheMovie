using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TheMovie.Model;
using TheMovie.MVVM;
using TheMovie.View;

namespace TheMovie.ViewModels
{
    public class MainWindowViewModel: ViewModelBase
    {
        private MovieRepository mR = new();
        private MovieViewModel selectedMovie;
        public MovieViewModel SelectedMovie
        {
            get { return selectedMovie; }
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

        public MainWindowViewModel()
        {
            MoviesVM = [];
            foreach (Movie movie in mR.GetMovies())
            {
                MoviesVM.Add(new MovieViewModel(movie));
            }
        }

        public RelayCommand AddCommand => new(execute => AddMovie());
        public RelayCommand DeleteCommand => new(execute => DeleteMovie(), canExecute => SelectedMovie != null);
        public RelayCommand SaveCommand => new(execute => SaveMovies());

        public void AddMovie()
        {
            int iD = mR.CalculateMovieId();
            Movie movie = new(iD, "", null, "");
            MovieViewModel mVM = new(movie);
            MoviesVM.Add(mVM);
            SelectedMovie = mVM;

            if (SelectedMovie != null)
            {
                DialogBox editMovieDialog = new();
                editMovieDialog.ShowDialog();
            }
        }

        public void DeleteMovie()
        {
            if (CheckDeletion(SelectedMovie) == true)
            {
                MoviesVM.Remove(SelectedMovie);
            }
            else { MessageBox.Show("Filmen indgår i en eller flere spillelister. Filmen skal fjernes fra alle spillelister, inden den kan slettes."); }
        }

        public static bool CheckDeletion(MovieViewModel movieVM)
        {
            CinemaRepository cR = new();
            foreach (Cinema cinema in cR.GetCinemas())
            {
                ScreenRepository sR = new(cinema.Name, cinema.ScreenCapacities);
                foreach (Screen screen in sR.GetScreens())
                {
                    PlayTimeRepository pR = new(cinema.Name, screen.Name);
                    foreach (PlayTime playTime in pR.GetPlayTimes())
                    {
                        if (playTime.Movie.MovieId == movieVM.Movie.MovieId)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        public void SaveMovies()
        {
            foreach (MovieViewModel movieViewModel in MoviesVM)
            {
                movieViewModel.Movie.Title = movieViewModel.Title;
                movieViewModel.Movie.Duration = movieViewModel.Duration;
                movieViewModel.Movie.Genre = movieViewModel.Genre;
            }

            List<Movie> movieList = [];
            foreach (MovieViewModel movieViewModel in MoviesVM)
            {
                movieList.Add(movieViewModel.Movie);
            }
            mR.UpdateMovies(movieList);

            MessageBox.Show("Listen er opdateret");
        }
    }
}
