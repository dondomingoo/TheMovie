namespace TheMovie.Models
{
    public class ScreenRepository
    {
        private List<Screen> screens = [];
        
        public ScreenRepository(string cinemaName, List<int> capacities)
        {
            for (int i = 0; i < capacities.Count; i++)
            {
                screens.Add(new(cinemaName, "Sal_" + (i+1).ToString(), capacities[i]));
            }
        }
        public List<Screen> GetScreens()
        {
            return screens;
        }
    }
}
