namespace TheMovie.Models
{
    public class ScreenRepository
    {
        private List<Screen> screens = [];
        
        public ScreenRepository(Cinema cinema, List<int> capacities)
        {
            for (int i = 0; i < capacities.Count; i++)
            {
                screens.Add(new(cinema, "Sal_" + (i+1).ToString(), capacities[i]));
            }
        }
        public List<Screen> GetScreens()
        {
            return screens;
        }
    }
}
