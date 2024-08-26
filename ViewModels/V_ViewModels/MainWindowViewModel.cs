using System.Collections.ObjectModel;
using System.Windows;
using TheMovie.Models;
using TheMovie.MVVM;
using TheMovie.ViewModels.M_ViewModels;
using TheMovie.Views;

namespace TheMovie.ViewModels.V_ViewModels
{
    public class MainWindowViewModel : ViewModelBase
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

        public int CalculateMovieId()
        {
            List<int?> ids = new List<int?>();
            foreach (Movie movie in mR.GetMovies())
            {
                ids.Add(movie.MovieId);
            }
            for (int i = 1; i <= ids.Count; i++)
            {
                if (!ids.Contains(i))
                {
                    return i;
                }
            }
            return ids.Count + 1;
        }

        public void AddMovie()
        {
            int iD = CalculateMovieId();
            Movie movie = new(iD, "", null, "", "", null);
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
                movieViewModel.Movie.Director = movieViewModel.Director;
                movieViewModel.Movie.PremiereDate = movieViewModel.PremiereDate;
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
