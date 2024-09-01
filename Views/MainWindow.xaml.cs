using System.Windows;
using TheMovie.ViewModels.V_ViewModels;

namespace TheMovie.Views
{
    public partial class MainWindow : Window
    { 
        public static MainWindowViewModel Mvm { get; } = new();
    
        public MainWindow()
        {
            InitializeComponent();
            DataContext = Mvm;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ScheduleView playTimeView = new();
            playTimeView.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ReservationsView rV = new ReservationsView();
            rV.Show();
            this.Close();
        }
    }
}