using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TheMovie.Commands;
using TheMovie.Model;

namespace TheMovie.ViewModels
{
    public class CinemaViewModel : INotifyPropertyChanged
    {
        public Cinema Cinema;
        public string Name => Cinema.Name; // Navn property som returnerer Cinema.Name og bruges til at binde til viewet.
        public ObservableCollection<PlayTime> PlayTimes => Cinema.PlayTimes; // PlayTimes property som returnerer Cinema.PlayTimes og bruges til at binde til viewet.


        public ICommand SaveScheduleCommand { get; private set; }
        public ICommand AddToScheduleCommand { get; private set; }

        //Constructor som tager en Cinema som parameter og initialiserer Cinema property og SaveScheduleCommand og AddToScheduleCommand.
        public CinemaViewModel(Cinema cinema)
        {
            Cinema = cinema;
            SaveScheduleCommand = new SaveScheduleCommand();
            AddToScheduleCommand = new AddToScheduleCommand();

            if (Cinema.PlayTimes == null)
            {
                Cinema.PlayTimes = new ObservableCollection<PlayTime>();
            }
        }

        //Playtimes property som returnerer Cinema.PlayTimes og bruges til at binde til viewet.
        public ObservableCollection<PlayTime> Playtimes
        {
            get { return Cinema.PlayTimes; }
            set
            {
                if (Cinema.PlayTimes != value)
                {
                    Cinema.PlayTimes = value;
                    OnPropertyChanged();
                }
            }
        }


        //AddToSchedule metoden tager en PlayTime som parameter og tilføjer den til Cinema.PlayTimes og kalder OnPropertyChanged metoden.
        public void SaveSchedule()
        {
            SaveScheduleToFile(Cinema);
        }


        //SaveToSchedule metoden gemmer Cinema.PlayTimes til en fil. Filen bliver gemt i samme mappe som programmet og har navnet Cinema.Name_Schedule.xlsx.
        //Hvis filen allerede eksisterer, bliver den overskrevet. ExcelPackage fra EPPlus biblioteket bliver brugt til at gemme filen. 
        private void SaveScheduleToFile(Cinema cinema)
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
                    worksheet.Cells[row, 7].Value = playTime.Movie.Duration.ToString("g"); // Duration property som returnerer DurationInMinutes i TimeSpan format. "g" format specifier bruges til at formatere TimeSpan objektet til en string.
                    worksheet.Cells[row, 8].Value = playTime.Seats;
                    worksheet.Cells[row, 9].Value = playTime.AvailableSeats;


                    row++;
                }

                var file = new FileInfo(fileName);
                package.SaveAs(file);
            }
        }

        //LoadSchedule metoden tjekker om der findes en fil med Cinema.Name_Schedule.xlsx og kalder LoadScheduleFromFile metoden hvis filen eksisterer.
        public void LoadSchedule()
        {
            string fileName = $"{Cinema.Name}_Schedule.xlsx";
            if (File.Exists(fileName))
            {
                LoadScheduleFromFile(fileName);
            }
        }

        //LoadScheduleFromFile metoden indlæser Cinema.PlayTimes fra en fil. Filen skal være i samme mappe som programmet og have navnet Cinema.Name_Schedule.xlsx.
        //ExcelPackage fra EPPlus biblioteket bliver brugt til at læse filen.
        
        private void LoadScheduleFromFile(string filePath)
        {
            OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheet = package.Workbook.Worksheets[0];
                int row = 2;
                PlayTimes.Clear();
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

                    var movie = new Movie { Title = movieTitle };
                    PlayTimes.Add(new PlayTime
                    {
                        Movie = movie,
                        StartTime = startTime,
                        Screen = cinemaHall

                    });

                    row++;
                }

                OnPropertyChanged(nameof(PlayTimes));
            }
        }

       

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
