using System.Windows;
using TheMovie.ViewModels;

namespace TheMovie.Views
{
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
