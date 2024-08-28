using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMovie.Model
{
    public class Datahandler
    {
        private static void LoadFromFile()
        { }
        public void LoadFromFile(List<Movie> movies)
        {
            if (!File.Exists("MovieDoc.txt"))
            {
                using StreamWriter sw = new("MovieDoc.txt");
            }

            using StreamReader sr = new("MovieDoc.txt");
            string[] lines = sr.ReadToEnd().Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            for (int i = 0; i < lines.Length - 1; i++)
            {
                string[] attributes = lines[i].Split(',');
                movies.Add(new Movie(attributes[0], int.Parse(attributes[1]), attributes[2], attributes[3], DateTime.Parse(attributes[4])));
            }
        }

        //Metode som lagrer listen med Movie-objekter til filen MovieDoc.txt
        public void SaveToFile(MovieRepository movieRepository)
        {
            using (StreamWriter writer = new("MovieDoc.txt"))
            {
                foreach (Movie movie in movieRepository.movies)
                {
                    writer.WriteLine($"{movie.Title},{movie.DurationInMinutes},{movie.Genre},{movie.Director},{movie.PremiereDate:yyyy-MM-dd}");
                }
            }
        }


        //Metode som lagrer listen med PlayTime-objekter til en Excel-fil med navnet på biografen og _Schedule.xlsx som filendelse.
        //Hvis filen allerede eksisterer, overskrives den.
        //Hver række i Excel-filen indeholder information om en PlayTime.
        //det er en overload af metoden SaveToFile som tager imod et Cinema objekt som parameter.
        public void SaveToFile(Cinema cinema)
        {
            OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            string fileName = $"{cinema.Name}_Schedule.xlsx";

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Schedule");

                worksheet.Cells[1, 1].Value = "Film";
                worksheet.Cells[1, 2].Value = "Starttid";
                worksheet.Cells[1, 3].Value = "Sluttid";
                worksheet.Cells[1, 4].Value = "Sal";
                worksheet.Cells[1, 5].Value = "Premiere dato";
                worksheet.Cells[1, 6].Value = "Instruktør";
                worksheet.Cells[1, 7].Value = "Varighed";
                worksheet.Cells[1, 8].Value = "Antal sæder i alt";
                worksheet.Cells[1, 9].Value = "Antal ledige sæder";

                int row = 2;
                foreach (var playTime in cinema.PlayTimes)
                {
                    worksheet.Cells[row, 1].Value = playTime.Movie.Title;
                    worksheet.Cells[row, 2].Value = playTime.StartTime.ToString("g");
                    worksheet.Cells[row, 3].Value = playTime.EndTime.ToString("g");
                    worksheet.Cells[row, 4].Value = playTime.Screen;
                    worksheet.Cells[row, 5].Value = playTime.Movie.PremiereDate.ToString("d");
                    worksheet.Cells[row, 6].Value = playTime.Movie.Director;
                    worksheet.Cells[row, 7].Value = playTime.Movie.Duration.ToString("g");
                    worksheet.Cells[row, 8].Value = playTime.Seats;
                    worksheet.Cells[row, 9].Value = playTime.AvailableSeats;

                    row++;
                }

                var file = new FileInfo(fileName);
                package.SaveAs(file);
            }
        }


        //overload af LoadFromFile metoden som tager imod et Cinema objekt som parameter.
        //Metoden indlæser PlayTime-objekter fra en Excel-fil med navnet på biografen og _Schedule.xlsx som filendelse.
        public void LoadFromFile(Cinema cinema)
        {
            string fileName = $"{cinema.Name}_Schedule.xlsx";
            if (!File.Exists(fileName)) return;

            OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            using (var package = new ExcelPackage(new FileInfo(fileName)))
            {
                var worksheet = package.Workbook.Worksheets[0];
                int row = 2;
                cinema.PlayTimes.Clear();
                while (worksheet.Cells[row, 1].Value != null)
                {
                    var movieTitle = worksheet.Cells[row, 1].Value.ToString();
                    var startTime = DateTime.Parse(worksheet.Cells[row, 2].Value.ToString());
                    var endTime = DateTime.Parse(worksheet.Cells[row, 3].Value.ToString());
                    var cinemaHall = worksheet.Cells[row, 4].Value.ToString();
                    var date = DateTime.Parse(worksheet.Cells[row, 5].Value.ToString());
                    var director = worksheet.Cells[row, 6].Value.ToString();
                    var duration = TimeSpan.Parse(worksheet.Cells[row, 7].Value.ToString());
                    var seats = int.Parse(worksheet.Cells[row, 8].Value.ToString());

                    var movie = new Movie { Title = movieTitle, DurationInMinutes = (int)duration.TotalMinutes, Genre = "", Director = director, PremiereDate = date };
                    cinema.PlayTimes.Add(new PlayTime
                    {
                        Movie = movie,
                        StartTime = startTime,
                        Screen = cinemaHall,
                        Seats = seats
                    });

                    row++;
                }
            }
        }
    }
}
