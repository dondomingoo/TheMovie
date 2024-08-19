using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TheMovie.ViewModels;
using TheMovie.Model;
using System.Windows;
using System.Xml.Linq;

namespace TheMovie.Commands
{
    public class SaveCommand : ICommand
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
                foreach (MovieViewModel movieViewModel in mvm.MoviesVM)
                {
                    movieViewModel.Movie.Title = movieViewModel.Title;
                    movieViewModel.Movie.Duration = movieViewModel.Duration;
                    movieViewModel.Movie.Genre = movieViewModel.Genre;
                }
                //if (mvm.SelectedMovie != null)
                //{
                //    mvm.SelectedMovie.Movie.Title = mvm.SelectedMovie.Title;
                //    mvm.SelectedMovie.Movie.Duration = mvm.SelectedMovie.Duration;
                //    mvm.SelectedMovie.Movie.Genre = mvm.SelectedMovie.Genre;
                //}
                mvm.SaveMovies();
                MessageBox.Show("Listen er opdateret");
            }
        }
    }
}
