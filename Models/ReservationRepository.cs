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
        private List<Reservation> reservations = [];
        private List<Reservation> restOfReservations = [];
        string fileName;

        public ReservationRepository(string cinemaName, DateTime? startTime, Movie movie, int screenNumber)
        {
            fileName = cinemaName + "_reservationer.csv";
            LoadReservations(fileName, startTime, movie, screenNumber);
        }

        public List<Reservation> GetReservations() { return reservations; }

        public void LoadReservations(string fileName, DateTime? startTime, Movie movie, int screenNumber)
        {
            string[] lines = DataHandler.LoadFromFile(fileName);
            for (int i = 1; i < lines.Length - 1; i++)
            {
                string[] attributes = lines[i].Split(';');

                if (DateTime.Parse(attributes[0]) == startTime && movie.MovieId == int.Parse(attributes[1]) && screenNumber == int.Parse(attributes[2]))
                {
                    reservations.Add(new Reservation(DateTime.Parse(attributes[0]), int.Parse(attributes[1]), int.Parse(attributes[2]), new Customer(attributes[3], int.Parse(attributes[4])), int.Parse(attributes[5])));
                }
                else 
                {
                    restOfReservations.Add(new Reservation(DateTime.Parse(attributes[0]), int.Parse(attributes[1]), int.Parse(attributes[2]), new Customer(attributes[3], int.Parse(attributes[4])), int.Parse(attributes[5])));
                }
            }
        }

        public void UpdateReservations(List<Reservation> reservationList)
        {
            reservations = reservationList;
            SaveReservations();
        }

        public void SaveReservations()
        {
                if (restOfReservations != null)
                {
                    reservations.AddRange(restOfReservations);
                }
                DataHandler.SaveDataFile("Spilletid;Film-id;Sal;Email;Telefonnummer;Antal billetter", reservations, fileName);
        }
    }
}
