using System.Windows.Input;

namespace TheMovie.MVVM
{
    public class RelayCommand(Action<object> execute, Predicate<object> canExecute = null) : ICommand
    {
        private Action<object> execute = execute;
        private Predicate<object> canExecute = canExecute;

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter)
        {
            return canExecute == null || canExecute(parameter);
        }

        public void Execute(object? parameter)
        {
            execute(parameter);
        }
    }
}
