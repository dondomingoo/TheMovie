using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TheMovie.ViewModels;
using TheMovie.Model;
using System.Windows;

namespace TheMovie.Commands
{   // AddCommand er en klasse som implementerer ICommand interfacet 
    // AddCommand har en event CanExecuteChanged som trigges når CanExecute metoden ændrer sig 
    // AddCommand har en metode CanExecute som returnerer en boolsk værdi
    // AddCommand har en metode Execute som tager et parameter og tilføjer en ny film til listen af film i MainViewModel
    public class AddCommand : ICommand
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
                mvm.AddMovie(new Movie { Title = "Title", DurationInMinutes = 0, Genre = "Genre", Director = "Instruktør", PremiereDate = DateTime.Today});
            }
        }
    }
}
