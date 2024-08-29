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
    public class AddToScheduleCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }
        // Execute metoden tager et parameter og tilføjer en ny PlayTime til listen af PlayTimes i MainViewModel
        // PlayTime objektet bliver oprettet med de valgte værdier fra brugeren
        // PlayTime objektet bliver tilføjet til den valgte Cinema
        // Hvis der ikke er valgt en Cinema eller en Movie, bliver der ikke tilføjet en PlayTime
        public void Execute(object? parameter)
        {
           if (parameter is MainViewModel mvm)
            {
                if (mvm.SelectedCinema != null && mvm.SelectedMovie != null)
                {
                    var newPlayTime = new PlayTime
                    {
                        Movie = mvm.SelectedMovie.Movie,
                        StartTime = mvm.SelectedTime,
                        Screen = mvm.SelectedScreen
                    };
                    mvm.SelectedCinema.PlayTimes.Add(newPlayTime);
                }
            }
        }
    }
}
