using System.Windows;

namespace TheMovie.Views
{
    public partial class DialogBox : Window
    {
        //private MainViewModel mvm = new();
        public DialogBox()
        {
            InitializeComponent();
            DataContext = MainWindow.Mvm;
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
