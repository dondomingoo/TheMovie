using System.ComponentModel;
using System.Windows.Input;

namespace TheMovie.MVVM
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler? propertyChanged = PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        //public ICommand AddCommand { get; } = new AddCommand();
        //public ICommand SaveCommand { get; } = new SaveCommand();
        //public ICommand DeleteCommand { get; } = new DeleteCommand();
    }
}
