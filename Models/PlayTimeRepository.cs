using TheMovie.MVVM;

namespace TheMovie.Models
{
    public class PlayTimeRepository
    {
        private MovieRepository mR = new MovieRepository();
        public string CinemaName { get; set; }
        public CinemaRepository CinemaRepository { get; set; }
        public List<PlayTime> PlayTimes { get; set; } = [];

        public PlayTimeRepository(string cinemaName, string screenName, int screenCapacity)
        {
            CinemaName = cinemaName;
            LoadPlayTimes(screenName, screenCapacity);
        }

        public PlayTimeRepository(string cinemaName, int? movieId, Cinema cinema)
        {
            CinemaName = cinemaName;
            LoadPlayTimesFromMovieId(movieId, cinema);
        }

        public List<PlayTime> GetPlayTimes()
        {
            return PlayTimes;
        }

        public void UpdatePlayTimes(List<PlayTime> playTimeList, Cinema cinema, Screen screen)
        {
            PlayTimes = playTimeList;
            SavePlayTimes(cinema, screen);
        }

        public void LoadPlayTimes(string screenName, int screenCapacity)
        {
            int screenNumber = int.Parse(new string(screenName.Where(char.IsDigit).ToArray()));
            string[] lines = DataHandler.LoadFromFile((CinemaName + "_Spilletider.csv"));
            for (int i = 1; i < lines.Length - 1; i++)
            {
                string[] attributes = lines[i].Split(';');
                if (screenNumber == int.Parse(attributes[7]))
                {
                    PlayTimes.Add(new PlayTime(DateTime.Parse(attributes[0]), mR.GetMovieFromId(int.Parse(attributes[6])), screenName, screenCapacity, CinemaName));
                }
            }
        }

        public void LoadPlayTimesFromMovieId(int? movieId, Cinema cinema)
        {
            string[] lines = DataHandler.LoadFromFile((CinemaName + "_Spilletider.csv"));
            for (int i = 1; i < lines.Length - 1; i++)
            {
                string[] attributes = lines[i].Split(';');
                if (movieId == int.Parse(attributes[6]))
                {
                    PlayTimes.Add(new PlayTime(DateTime.Parse(attributes[0]), mR.GetMovieFromId(int.Parse(attributes[6])), "Sal_" + int.Parse(attributes[7]), cinema.ScreenCapacities[int.Parse(attributes[7]) - 1], CinemaName));
                }
            }
        }

        public void SavePlayTimes(Cinema cinema, Screen s)
        {
            foreach (Screen screen in cinema.Screens.GetScreens())
            {
                if (screen.Name != s.Name)
                {
                    LoadPlayTimes(screen.Name, screen.Capacity);
                }
            }
            DataHandler.SaveDataFile("Spilletidspunkt;Rengøring;Titel;Genre;Instruktør;Premieredato;Film-id;Sal", PlayTimes, (CinemaName + "_Spilletider.csv"));
        }
    }
}
