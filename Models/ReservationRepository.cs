using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMovie.MVVM;

namespace TheMovie.Models
{
    public class ReservationRepository
    {
        private List<Reservation> reservations { get; set; }
        string fileName;

        public ReservationRepository(Cinema cinema)
        {
            string fileName = cinema.Name + "_reservationer.csv";
            LoadReservations(fileName);
        }

        public List<Reservation> GetAllReservations() { return reservations; }

        public void LoadReservations(string fileName)
        {
            string[] lines = DataHandler.LoadFromFile(fileName);
            for (int i = 1; i < lines.Length - 1; i++)
            {
                string[] attributes = lines[i].Split(';');
                reservations.Add(new Reservation(int.Parse(attributes[0]), int.Parse(attributes[1]), new Customer(attributes[2], int.Parse(attributes[3])), int.Parse(attributes[4])));
            }
        }

        public void SaveReservations()
        {
            DataHandler.SaveDataFile("Film-id;Sal;Email;Telefonnummer;Antal billetter", reservations, fileName);
        }
    }
}
