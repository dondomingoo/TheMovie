using TheMovie.MVVM;

namespace TheMovie.Models
{
    public class PlayTimeRepository
    {
        private MovieRepository mR = new MovieRepository();
        public Cinema Cinema { get; set; }
        public List<PlayTime> PlayTimes { get; set; } = [];

        public PlayTimeRepository(Cinema cinema, string screenName, int screenCapacity)
        {
            Cinema = cinema;
            LoadPlayTimes(screenName, screenCapacity);
        }

        public PlayTimeRepository(Cinema cinema, int? movieId)
        {
            Cinema = cinema;
            LoadPlayTimesFromMovieId(movieId);
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
            string[] lines = DataHandler.LoadFromFile((Cinema.Name + "_Spilletider.csv"));
            for (int i = 1; i < lines.Length - 1; i++)
            {
                string[] attributes = lines[i].Split(';');
                if (screenNumber == int.Parse(attributes[7]))
                {
                    PlayTimes.Add(new PlayTime(DateTime.Parse(attributes[0]), mR.GetMovieFromId(int.Parse(attributes[6])), screenName, screenCapacity, Cinema));
                }
            }
        }

        public void LoadPlayTimesFromMovieId(int? movieId)
        {
            string[] lines = DataHandler.LoadFromFile((Cinema.Name + "_Spilletider.csv"));
            for (int i = 1; i < lines.Length - 1; i++)
            {
                string[] attributes = lines[i].Split(';');
                if (movieId == int.Parse(attributes[6]))
                {
                    PlayTimes.Add(new PlayTime(DateTime.Parse(attributes[0]), mR.GetMovieFromId(int.Parse(attributes[6])), "Sal_" + int.Parse(attributes[7]), Cinema.ScreenCapacities[int.Parse(attributes[6]) - 1], Cinema));
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
            DataHandler.SaveDataFile("Spilletidspunkt;Rengøring;Titel;Genre;Instruktør;Premieredato;Film-id;Sal", PlayTimes, (Cinema.Name + "_Spilletider.csv"));
        }
    }
}
