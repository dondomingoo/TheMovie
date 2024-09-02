using TheMovie.Models;

namespace TheMovie.ViewModels.M_ViewModels
{
    public class PlayTimeViewModel
    {
        public PlayTime PlayTime { get; set; }
        public DateTime? StartTime { get; set; }
        public string RunningTime { get; set; }
        public Movie Movie { get; set; }
        public int ScreenNumber { get; set; }
        public string ScreenName { get; set; }
        public int? RemainingTickets { get; set; }
        public ReservationRepository ResRepository { get; set; }

        public PlayTimeViewModel(PlayTime playTime)
        {
            PlayTime = playTime;
            StartTime = playTime.StartTime;
            Movie = playTime.Movie;
            RunningTime = $"{StartTime?.ToString("dd/MM/yyyy HH:mm")}-{(StartTime + TimeSpan.FromMinutes(double.Parse(Movie.Duration.ToString()) + 30))?.ToString("HH:mm")}";
            ScreenNumber = PlayTime.ScreenNumber;
            ScreenName = $"Sal {playTime.ScreenNumber}";
            ResRepository = playTime.ResRepository;
            int? soldTickets = 0;
            if (ResRepository.GetReservations() != null)
            {
                foreach (Reservation reservation in ResRepository.GetReservations())
                {
                    soldTickets += reservation.NumberOfTickets;
                }
            }
            RemainingTickets = playTime.ScreenCapacity - soldTickets;
        }
    }
}
