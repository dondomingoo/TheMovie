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

namespace TheMovie.Views
{
    /// <summary>
    /// Interaction logic for ReservationsDialogBox1.xaml
    /// </summary>
    public partial class ReservationsDialogBox1 : Window
    {
        public ReservationsDialogBox1()
        {
            InitializeComponent();
            DataContext = ReservationsView1.Rvm;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
