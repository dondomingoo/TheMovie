using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMovie.ViewModels
{
    public class MoviesVM
    {
        public ObservableCollection<MovieVM> mVMs { get; set; }

        public MoviesVM() 
        {
            mVMs = [];
            foreach (Movie movie in MovieRepository.Movies)
            {
                mVMs.Add(new MovieVM(movie));
            }
        }

        public void AddMovie()
        {
            Movie movie = new Movie("Titel", 0, "Genre");
            MovieVM mVM = new(movie);
            mVMs.Add(mVM);
            SelectedRoom = rVM;
        }

        public void SaveMovies()
        {
        }
    }
}
