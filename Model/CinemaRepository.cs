using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMovie.Model
{
    internal class CinemaRepository
    {
        private List<Cinema> cinemas;

        public CinemaRepository() {
        cinemas = new()
        {
           new Cinema("Hjerm", new List<int> {35}),
           new Cinema("Videbæk", new List<int> {70}),
           new Cinema("Thorsminde", new List<int> {25}),
           new Cinema("Ræhr", new List<int> {30, 50})
        };
        }
        public List<Cinema> GetCinemas()
        {
            return cinemas;
        }
    }
}
