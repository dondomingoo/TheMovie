using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
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

namespace TheMovie.Views
{
    /// <summary>
    /// Interaction logic for ReservationsDialogBox.xaml
    /// </summary>
    public partial class ReservationsView2 : Window
    {
        public ReservationsView2()
        {
            InitializeComponent();
            DataContext = ReservationsView1.Rvm;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ScheduleView playTimeView = new();
            playTimeView.Show();
            this.Close();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow main = new();
            main.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            ReservationsView1 rV = new ReservationsView1();
            rV.Show();
            this.Close();
        }
    }
}
