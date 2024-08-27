using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMovie.Model
{
    public class Reservation
    {
        public int TicketAmount { get; set; }
        public Customer Customer { get; set; }
    }
}
