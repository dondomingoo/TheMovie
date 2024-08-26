using TheMovie.MVVM;

namespace TheMovie.Models
{
    public class PlayTimeRepository
    {
        private MovieRepository mR = new MovieRepository();
        public string CinemaName { get; set; }
        public string ScreenName { get; set; }
        public List<PlayTime> PlayTimes { get; set; } = [];

        public PlayTimeRepository(string cinemaName, string screenName)
        {
            CinemaName = cinemaName;
            ScreenName = screenName;
            LoadPlayTimes();
        }

        public List<PlayTime> GetPlayTimes()
        {
            return PlayTimes;
        }

        public void UpdatePlayTimes(List<PlayTime> playTimeList)
        {
            PlayTimes = playTimeList;
            SavePlayTimes();
        }

        public void LoadPlayTimes()
        {
            string[] lines = DataHandler.LoadFromFile((CinemaName + "_" + ScreenName + "_Spilletider.csv"));
            for (int i = 1; i < lines.Length - 1; i++)
            {
                string[] attributes = lines[i].Split(';');
                PlayTimes.Add(new PlayTime(DateTime.Parse(attributes[0]), mR.GetMovieFromId(int.Parse(attributes[6]))));
            }
        }

        public void SavePlayTimes()
        {
            DataHandler.SaveDataFile("Spilletidspunkt;Rengøring;Titel;Genre;Instruktør;Premieredato;Film-id",PlayTimes, (CinemaName + "_" + ScreenName + "_Spilletider.csv"));
        }
    }
}
