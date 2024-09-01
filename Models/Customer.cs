using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMovie.Models
{
    public class Customer(string eMail, int phoneNumber)
    {
        public string Email { get; set; } = eMail;
        public int PhoneNumber { get; set; } = phoneNumber;

        public override string ToString()
        {
            return $"{Email};{PhoneNumber}";
        }
    }
}
