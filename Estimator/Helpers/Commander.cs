using System;
using System.Windows.Input;

namespace Estimator.Helpers
{
    public class Commander : ICommand
    {
        private Action<object> execute;
        private Predicate<object> canExecute;
        public Commander(Action<object> execute, Predicate<object> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }
        public bool CanExecute(object parameter)
        {
            bool response = canExecute == null ? true : canExecute(parameter);
            return response;

        }
        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public void Execute(object parameter)
        {
            execute(parameter);
        }
    }
}
