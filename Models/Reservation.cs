using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMovie.Models
{
    public class Reservation(DateTime? startTime, int? movieId, int screenNumber, Customer customer, int? numberOfTickets): IEntity
    {
        public Customer Customer { get; set; } = customer;
        public int? NumberOfTickets { get; set; } = numberOfTickets;

        public override string ToString()
        {
            return $"{startTime};{movieId};{screenNumber};{Customer.ToString()};{NumberOfTickets}";
        }
    }
}
