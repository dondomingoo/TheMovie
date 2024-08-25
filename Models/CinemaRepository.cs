namespace TheMovie.Models
{
    public class CinemaRepository
    {
        private List<Cinema> cinemas;

        public CinemaRepository() {
        cinemas =
        [
           new Cinema("Hjerm", [35]),
           new Cinema("Videbæk", [70]),
           new Cinema("Thorsminde", [25]),
           new Cinema("Ræhr", [30, 50])
        ];
        }
        
        public List<Cinema> GetCinemas()
        {
            return cinemas;
        }
    }
}
