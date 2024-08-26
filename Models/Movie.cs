using System.IO;

namespace TheMovie.Models
{
    public class Movie(int? movieId, string title, int? duration, string genre, string director, DateTime? premiereDate): IEntity
    {
        public int? MovieId { get; } = movieId;
        public string Title { get; set; } = title;
        public int? Duration { get; set; } = duration;
        public string Genre { get; set; } = genre;
        public string Director { get; set; } = director;
        public DateTime? PremiereDate { get; set; } = premiereDate;

        public override string ToString()
        {
            return $"{MovieId};{Title};{Duration};{Genre};{Director};{PremiereDate}";
        }
    }
}
