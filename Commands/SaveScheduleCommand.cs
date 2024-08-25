using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TheMovie.ViewModels;

namespace TheMovie.Commands
{
    class SaveScheduleCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }
        // Execute metoden tager et parameter og gemmer PlayTimes listen i MainViewModel til en fil
        
        public void Execute(object? parameter)
        {
            if (parameter is MainViewModel mvm)
            {
                mvm.SaveToSchedule();
            }
        }
    }
}
