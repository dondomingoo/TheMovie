namespace TheMovie.Models
{
    public class Screen(Cinema cinema, string screenname, int capacity)
    {
        public Cinema Cinema { get; } = cinema;
        public string Name { get; } = screenname;
        public int Capacity { get; } = capacity;
        public PlayTimeRepository PlayTimes { get; } = new(cinema, screenname, capacity);
    }
}
