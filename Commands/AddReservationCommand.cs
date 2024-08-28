using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TheMovie.Model;
using TheMovie.ViewModels;

namespace TheMovie.Commands
{
    public class AddReservationCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (parameter is MainViewModel mvm)
            {
                if (mvm.SelectedPlayTime != null)
                {
                    var newReservation = new Reservation
                    {
                        TicketAmount = mvm.SelectedTicketAmount,
                        Customer.Name = mvm.SelectedCustomerName,
                        Customer.PhoneNumber = mvm.SelectedCustomerPhoneNumber
                        Customer.Email = mvm.SelectedCustomerEmail
                    };
                }
            }

        }
    }
}
