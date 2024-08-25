using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TheMovie.ViewModels;

namespace TheMovie.View
{
    /// <summary>
    /// Interaction logic for CinemaView.xaml
    /// </summary>
    public partial class ScheduleView : Window
    {
        private ScheduleViewModel svm = new();
        public ScheduleView()
        {
            InitializeComponent();
            DataContext = svm;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new();
            main.Show();
            this.Close();
        }
    }
}
