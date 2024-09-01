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
    public partial class ReservationsDialogBox : Window
    {
        public ReservationsDialogBox()
        {
            InitializeComponent();
            DataContext = ReservationsView.Rvm;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
