using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TheMovie.ViewModel;
using TheMovie.Model;
using System.Windows;

namespace TheMovie.Commands
{
    public class AddCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (parameter is MoviesViewModel mvm)
            {
                mvm.Movies.Add(new Movie { Title="Title", Duration=0, Genre="Genre"});
            }
        }
    }
}
