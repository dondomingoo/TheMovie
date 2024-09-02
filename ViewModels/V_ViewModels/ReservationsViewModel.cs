using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TheMovie.Models;
using TheMovie.MVVM;
using TheMovie.ViewModels.M_ViewModels;
using TheMovie.Views;

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
                    CheckSelectionReservations();
                }
            }
        }

        private ReservationRepository rR;
        public ObservableCollection<ReservationViewModel> ReservationsVM { get; set; } = [];
        private ReservationViewModel selectedReservation;
        public ReservationViewModel SelectedReservation
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
                    CheckSelectionPlayTimes();
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

        public RelayCommand AddCommand => new(execute => AddReservation());
        public RelayCommand DeleteCommand => new(execute => DeleteReservation(), canExecute => SelectedMovie != null);
        public RelayCommand SaveCommand => new(execute => SaveReservations());

        public void AddReservation()
        {
            Reservation reservation = new(SelectedPlayTime.StartTime, selectedPlayTime.Movie.MovieId, selectedPlayTime.ScreenNumber, new Customer(null, null), null);
            ReservationViewModel rVM = new(reservation);
            ReservationsVM.Add(rVM);
            SelectedReservation = rVM;

            if (SelectedReservation != null)
            {
                ReservationsDialogBox1 editReservationDialog = new();
                editReservationDialog.ShowDialog();
            }
        }

        public void DeleteReservation()
        {
            ReservationsVM.Remove(SelectedReservation);
        }
        public void SaveReservations()
        {
            foreach (ReservationViewModel rVM in ReservationsVM)
            {
                rVM.Reservation.NumberOfTickets = rVM.NumberOfTickets;
                rVM.Reservation.Customer.PhoneNumber = rVM.Customer.PhoneNumber;
                rVM.Reservation.Customer.Email = rVM.Customer.Email;
            }

            List<Reservation> reservationList = [];
            foreach (ReservationViewModel rVM in ReservationsVM)
            {
                reservationList.Add(rVM.Reservation);
            }
            rR.UpdateReservations(reservationList);

            MessageBox.Show("Listen er opdateret");
        }

        public void CheckSelectionPlayTimes()
        {
            if (SelectedMovie != null && SelectedCinema != null)
            {
                pR = new(SelectedCinema.Name, SelectedMovie.Movie.MovieId, SelectedCinema.Cinema);
                PlayTimesVM.Clear();
                foreach (PlayTime playTime in pR.GetPlayTimes())
                {
                    PlayTimesVM.Add(new(playTime));
                }
            }
        }

        public void CheckSelectionReservations()
        {
            if (SelectedPlayTime != null && SelectedMovie != null)
            {
                rR = new(SelectedCinema.Name, SelectedPlayTime.StartTime, selectedMovie.Movie, SelectedPlayTime.ScreenNumber);
                
                if (rR.GetReservations() != null)
                {
                    ReservationsVM.Clear();
                    foreach (Reservation reservation in rR.GetReservations())
                    {
                        ReservationsVM.Add(new(reservation));
                    }
                }
            }
        }
    }
}
