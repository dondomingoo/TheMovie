using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TheMovie.View;
using TheMovie.ViewModels;

namespace TheMovie
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    { 
        MainViewModel mvm = new MainViewModel();
        //MainWindow klassen er en partial klasse, som er en del af MainWindow klassen
        //InitializeComponent metoden initialiserer MainWindow klassen og DateContext sætter DataContext til MainViewModel
        public MainWindow()
        {
            InitializeComponent();
            DataContext = mvm;
        }

        //Button_Click metoden åbner ScheduleWindow
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ScheduleWindow scheduleWindow = new ScheduleWindow();
            scheduleWindow.Show();
        }

       
    }
}