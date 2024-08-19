using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TheMovie.ViewModels;
using TheMovie.Model;
using System.Windows;
using TheMovie.View;

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
            if (parameter is MainViewModel mvm)
            {
                mvm.AddMovie();

                if (mvm.SelectedMovie != null)
                {
                    DialogBox editMovieDialog = new DialogBox(mvm);
                    editMovieDialog.ShowDialog();
                }
            }
        }
    }
}
