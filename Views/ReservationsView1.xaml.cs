using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TheMovie.ViewModels.V_ViewModels;

namespace TheMovie.Views
{
    /// <summary>
    /// Interaction logic for ReservationsView.xaml
    /// </summary>
    public partial class ReservationsView1 : Window
    {
        public static ReservationsViewModel Rvm { get; } = new();
        public ReservationsView1()
        {
            InitializeComponent();
            DataContext = Rvm;
            Rvm.SelectedCinema = null;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new();
            main.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ScheduleView playTimeView = new();
            playTimeView.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ReservationsView2 reservationsView2 = new();
            reservationsView2.Show();
            this.Close();
        }
    }
}
