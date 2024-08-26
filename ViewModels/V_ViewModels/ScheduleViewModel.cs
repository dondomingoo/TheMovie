using System.Collections.ObjectModel;
using TheMovie.Models;
using TheMovie.MVVM;
using TheMovie.ViewModels.M_ViewModels;

namespace TheMovie.ViewModels.V_ViewModels
{
    public class ScheduleViewModel : ViewModelBase
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
                    SelectedDate = null;
                    SelectedTimeSpan = null;
                }
            }
        }

        private ScreenViewModel selectedScreen;
        public ScreenViewModel SelectedScreen
        {
            get { return selectedScreen; }
            set
            {
                if (selectedScreen != value)
                {
                    selectedScreen = value;
                    OnPropertyChanged("SelectedScreen");
                    CheckSelection();
                }
            }
        }

        private MovieRepository mR = new();
        public ObservableCollection<MovieViewModel> MoviesVM { get; set; }
        private MovieViewModel? selectedMovie;
        public MovieViewModel? SelectedMovie
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

        private string? selectedTimeSpan;
        public string? SelectedTimeSpan
        {
            get { return selectedTimeSpan; }
            set
            {
                if (selectedTimeSpan != value)
                {
                    selectedTimeSpan = value;
                    OnPropertyChanged("SelectedTimeSpan");
                }
            }
        }

        private DateTime? selectedDate;
        public DateTime? SelectedDate
        {
            get { return selectedDate; }
            set
            {
                if (selectedDate != value)
                {
                    selectedDate = value;
                    OnPropertyChanged("SelectedDate");
                }
            }
        }

        public ScheduleViewModel()
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

            SelectedDate = null;
        }

        public RelayCommand AddCommand => new(execute => AddPlayTime(), canExecute => SelectedTimeSpan != null);
        public RelayCommand DeleteCommand => new(execute => DeletePlayTime(), canExecute => SelectedPlayTime != null);
        public RelayCommand ClearCommand => new(execute => ClearAllPlayTimes());

        public void ClearAllPlayTimes()
        {
            CinemaRepository cR = new();
            foreach (Cinema cinema in cR.GetCinemas())
            {
                ScreenRepository sR = new(cinema.Name, cinema.ScreenCapacities);
                foreach (Screen screen in sR.GetScreens())
                {
                    PlayTimeRepository pR = new(cinema.Name, screen.Name);
                    pR.UpdatePlayTimes([]);
                }
            }
            if (PlayTimesVM.Count != 0)
            {
                PlayTimesVM.Clear();
            }
        }

        public void CheckSelection()
        {
            if (SelectedScreen != null && SelectedCinema != null)
            {
                pR = new(SelectedCinema.Name, SelectedScreen.Name);
                PlayTimesVM.Clear();
                foreach (PlayTime playTime in pR.GetPlayTimes())
                {
                    PlayTimesVM.Add(new(playTime));
                }
            }
        }

        public void AddPlayTime()
        {
            DateTime? dateTime = SelectedDate + TimeSpan.Parse(SelectedTimeSpan);
            PlayTime playTime = new(dateTime, SelectedMovie.Movie);
            PlayTimeViewModel pVM = new(playTime);
            PlayTimesVM.Add(pVM);
            SelectedPlayTime = pVM;
            foreach (PlayTimeViewModel playTimeViewModel in PlayTimesVM)
            {
                playTimeViewModel.PlayTime.StartTime = playTimeViewModel.StartTime;
                playTimeViewModel.PlayTime.Movie = playTimeViewModel.Movie;
            }
            SavePlayTimes();
        }

        public void DeletePlayTime()
        {
            PlayTimesVM.Remove(SelectedPlayTime);
            SavePlayTimes();
        }

        public void SavePlayTimes()
        {
            List<PlayTime> playTimeList = [];
            foreach (PlayTimeViewModel playTimeViewModel in PlayTimesVM)
            {
                playTimeList.Add(playTimeViewModel.PlayTime);
            }
            pR.UpdatePlayTimes(playTimeList);
        }
    }
}

