﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TheMovie.Commands;
using TheMovie.Model;

namespace TheMovie.ViewModels
{
    public class MainViewModel:INotifyPropertyChanged
    {
        public ObservableCollection<MovieViewModel> movieViewModels { get; set; }
        private MovieRepository movieRepository;

        private MovieViewModel _selectedMovie;

       

        public MovieViewModel SelectedMovie
        {
            get { return _selectedMovie; }
            set
            {
                _selectedMovie = value;
                OnPropertyChanged(nameof(SelectedMovie));
            }
        }

        public ICommand AddCommand { get; set; }

        public MainViewModel()
        {
            movieRepository = new MovieRepository();
            movieViewModels = new ObservableCollection<MovieViewModel>();
            LoadMoviesFromRepository();


            foreach (Movie movie in movieRepository.GetMovies())
            {
                movieViewModels.Add(new MovieViewModel(movie));
            }
            AddCommand = new AddCommand();
        }

        private void LoadMoviesFromRepository()
        {
            foreach (Movie movie in movieRepository.movies)
            {
                movieViewModels.Add(new MovieViewModel(movie));
            }
        }

        public void AddMovie (Movie movie)
        {
            movieRepository.AddMovie(movie);
            movieViewModels.Add(new MovieViewModel(movie));
            UpdateMovieList();
        }

        public void UpdateMovieList()
        {
            List<Movie> movieList = new List<Movie>();
            foreach (MovieViewModel movieViewModel in movieViewModels)
            {
                movieList.Add(movieViewModel.Movie);
            }
            movieRepository.Update(movieList);
        }
        //public MainViewModel() 
        //{
        //    movieViewModels = []; 
        //    foreach (Movie movie in MovieRepository.movies)
        //    {
        //        movieViewModels.Add(new MovieViewModel(movie));
        //    }
        //}

        //public void AddMovie(Movie movie)
        //{
        //    MovieViewModel mVM = new(movie);
        //    movieViewModels.Add(mVM);
        //}

        //public void UpdateMovieList()
        //{
        //    List<Movie> movieList = [];
        //    foreach (MovieViewModel movieViewModel in movieViewModels) 
        //    {
        //        movieList.Add(movieViewModel.Movie);
        //    }
        //    MovieRepository.Update(movieList);
        //}

        // slet "Movies" fra "mvm.Movies.Add..." (og metoden hedder AddMovie)"
        // tilføj "mvm.UpdateMovieList();"
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
