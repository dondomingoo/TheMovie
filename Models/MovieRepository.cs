﻿using TheMovie.MVVM;

namespace TheMovie.Models
{
    public class MovieRepository
    {
        private List<Movie> movies = [];
        private string fileName;

        public MovieRepository(string fileName = "TheMovies.csv")
        {
            this.fileName = fileName;
            LoadMovies();
        }

        public Movie GetMovieFromId(int movieId)
        {
            {
                for (int i = 0; i < movies.Count; i++)
                {
                    if (movies[i].MovieId == movieId)
                    {
                        return movies[i];
                    }
                }
                throw new KeyNotFoundException($"No movie found with ID {movieId}");
            }
        }

        public List<Movie> GetMovies()
        {
            return movies;
        }
        
        public void UpdateMovies(List<Movie> movieList)
        {
            movies = movieList;
            SaveMovies();
        }

        public void LoadMovies()
        {
            string[] lines = DataHandler.LoadFromFile(fileName);
            for (int i = 1; i < lines.Length - 1; i++)
            {
                string[] attributes = lines[i].Split(';');
                movies.Add(new Movie(int.Parse(attributes[0]), attributes[1], int.Parse(attributes[2]), attributes[3], attributes[4], DateTime.Parse(attributes[5])));
            }
        }

        public void SaveMovies()
        {
            DataHandler.SaveDataFile("Film-id;Titel;Varighed (min.);Genre;Instruktør;Premieredato", movies, fileName);
        }
    }
}