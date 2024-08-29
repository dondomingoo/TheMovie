using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMovie.Commands;

namespace TheMovie.Model
{
    class CinemaRepository
    {
        private readonly List<Cinema> _cinemas;
        private Datahandler _datahandler = new Datahandler();

        public CinemaRepository()
        {
            _cinemas = new List<Cinema>();
            InitializeCinemas();
        }
        //public class CinemaRepository som indeholder en liste af Cinema objekter og en metode til at tilføje en PlayTime til en Cinema.
        private void InitializeCinemas()
        {
            AddCinema(new Cinema { Name = "Hjerm" });
            AddCinema(new Cinema { Name = "Videbæk" });
            AddCinema(new Cinema { Name = "Thorsminde" });
            AddCinema(new Cinema { Name = "Ræhr" });
        }
        

        
        private void AddCinema(Cinema cinema)
        {
            _cinemas.Add(cinema);
        }

        public List<Cinema> GetCinemas()
        {
            return _cinemas;
        }

        public void SaveCinemaSchedule(Cinema cinema)
        {
            _datahandler.SaveToFile(cinema);
        }

        public void LoadCinemaSchedule(Cinema cinema)
        {
            _datahandler.LoadFromFile(cinema);
        }
    }
}
