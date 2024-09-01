using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMovie.Models;

namespace TheMovie.ViewModels.M_ViewModels
{
    public class ReservationViewModel(Reservation reservation)
    {
        public Reservation Reservation { get; set; } = reservation;
        public Customer Customer { get; set; } = reservation.Customer;
        public int NumberOfTickets { get; set; } = reservation.NumberOfTickets;
    }
}
