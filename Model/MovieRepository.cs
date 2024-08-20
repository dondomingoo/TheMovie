﻿using System.IO;
using System.Windows;
using TheMovie.Model;

public class MovieRepository
{
    private List<Movie> movies = [];
    private string fileName;

    public MovieRepository(string fileName = "MovieDoc.csv")
    {
        this.fileName = fileName;
        LoadMovies();
    }
    //public void AddMovie(Movie movie)
    //{
    //    movies.Add(movie);
    //    SaveToFile();
    //}
    public List<Movie> GetMovies()
    {
        return movies;
    }
    public void UpdateMovies(List<Movie> movieList)
    {
        //for (int i = 0; i < movies.Count; i++)
        //{
        //    if (movies[i].MovieId == movie.MovieId)
        //    {
        //        movies[i] = movie;
        //    }
        //}
        movies = movieList;
        SaveMovies();
    }
    //public void DeleteMovie(Movie movie)
    //{
    //    for (int i = 0; i < movies.Count; i++)
    //    {
    //        if (movies[i].MovieId == movie.MovieId)
    //        {
    //            movies.Remove(movies[i]);
    //        }
    //    }
    //    //SaveToFile();
    //}
    //public int CalculateMovieId()
    //{
    //    List<int> ids = new List<int>();
    //    foreach (Movie movie in movies)
    //    {
    //        ids.Add(movie.MovieId);
    //    }
    //    for (int i = 1; i <= ids.Count; i++)
    //    {
    //        if (!ids.Contains(i))
    //        {
    //            return i;
    //        }
    //    }
    //    return ids.Count + 1;
    //}
    public void LoadMovies()
    {
        string[] lines = DataHandler.LoadFromFile(fileName);
        for (int i = 0; i < lines.Length - 1; i++)
        {
            string[] attributes = lines[i].Split(';');
            movies.Add(new Movie(attributes[0], int.Parse(attributes[1]), attributes[2]));
        }
    }
    public void SaveMovies()
    {
        DataHandler.SaveDataFile(movies, fileName);
    }
}
