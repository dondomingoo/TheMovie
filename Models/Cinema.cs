namespace TheMovie.Models
{
    public class Cinema(string name, List<int> capacities)
    {
        public string Name { get; } = name;
        public ScreenRepository Screens { get; } = new(name, capacities);
        public List<int> ScreenCapacities { get; } = capacities;
    }
}
