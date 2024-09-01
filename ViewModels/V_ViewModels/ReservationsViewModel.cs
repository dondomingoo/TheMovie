    using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMovie.Models;
using TheMovie.MVVM;
using TheMovie.ViewModels.M_ViewModels;

namespace TheMovie.ViewModels.V_ViewModels
{
    public class ReservationsViewModel : ViewModelBase
    {
        private PlayTimeRepository pR;
        public ObservableCollection<PlayTimeViewModel> PlayTimesVM { get; set; } = [];
        private PlayTimeViewModel selectedPlayTime;
        public PlayTimeViewModel SelectedPlayTime
        {
            get { return selectedPlayTime; }
            set
            {
                if (selectedPlayTime != value)
                {
                    selectedPlayTime = value;
                    OnPropertyChanged("SelectedPlayTime");
                }
            }
        }

        private ReservationRepository rR;
        public ObservableCollection<PlayTimeViewModel> ReservationsVM { get; set; } = [];
        private PlayTimeViewModel selectedReservation;
        public PlayTimeViewModel SelectedReservation
        {
            get { return selectedReservation; }
            set
            {
                if (selectedReservation != value)
                {
                    selectedReservation = value;
                    OnPropertyChanged("SelectedReservation");
                }
            }
        }

        private CinemaRepository cR = new();
        public ObservableCollection<CinemaViewModel> CinemasVM { get; set; }
        private CinemaViewModel selectedCinema;
        public CinemaViewModel SelectedCinema
        {
            get { return selectedCinema; }
            set
            {
                if (selectedCinema != value)
                {
                    selectedCinema = value;
                    OnPropertyChanged("SelectedCinema");
                    PlayTimesVM.Clear();
                    SelectedMovie = null;
                }
            }
        }

        private MovieRepository mR = new();
        public ObservableCollection<MovieViewModel> MoviesVM { get; set; }
        private MovieViewModel selectedMovie;
        public MovieViewModel? SelectedMovie
        {
            get { return selectedMovie; }
            set
            {
                if (selectedMovie != value)
                {
                    selectedMovie = value;
                    OnPropertyChanged("SelectedMovie");
                    CheckSelection();
                }
            }
        }

        public ReservationsViewModel() 
        {
            CinemasVM = [];
            foreach (Cinema cinema in cR.GetCinemas())
            {
                CinemasVM.Add(new CinemaViewModel(cinema));
            }

            MoviesVM = [];
            foreach (Movie movie in mR.GetMovies())
            {
                MoviesVM.Add(new MovieViewModel(movie));
            }
        }
        public void CheckSelection()
        {
            if (SelectedMovie != null && SelectedCinema != null)
            {
                pR = new(SelectedCinema.Cinema, SelectedMovie.Movie.MovieId);
                PlayTimesVM.Clear();
                foreach (PlayTime playTime in pR.GetPlayTimes())
                {
                    PlayTimesVM.Add(new(playTime));
                }
            }
        }
    }
}
