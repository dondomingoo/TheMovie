using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TheMovie.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<MovieViewModel> movieViewModels { get; set; }

        public MainViewModel() 
        {
            movieViewModels = [];
            foreach (Movie movie in MovieRepository.Movies)
            {
                movieViewModels.Add(new MovieVM(movie));
            }
        }

        public void AddMovie(Movie movie)
        {
            MovieVM mVM = new(movie);
            movieViewModels.Add(mVM);
        }

        public void UpdateMovieList()
        {
            List<Movie> movieList = [];
            foreach (MovieViewModel movieViewModel in movieViewModels) 
            {
                movieList.Add(movieViewModel.Movie);
            }
            MovieRepository.Update(movieList);
        }

        // slet "Movies" fra "mvm.Movies.Add..." (og metoden hedder AddMovie)"
        // tilføj "mvm.UpdateMovieList();"

    }
}
