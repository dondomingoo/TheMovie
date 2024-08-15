using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TheMovie.ViewModels;

namespace TheMovie.Commands
{
    //SaveCommand Klasse implementiert das ICommand Interface
    //savecommand har en event CanExecuteChanged som trigges når CanExecute metoden ændrer sig
    //savecommand har en metode CanExecute som returnerer en boolsk værdi
    //savecommand har en metode Execute som tager et parameter og gemmer en film i listen af film i MainViewModel
    internal class SaveCommand : ICommand
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
                mvm.SaveMovie();
            }

        }
    
    }
}
