using System;
using System.Windows.Input;

namespace Calculator.Mvvm
{
    public abstract class DelegateCommandBase:ICommand
    {
        public abstract bool CanExecute(object parameter);

        public abstract void Execute(object parameter);

        public event EventHandler CanExecuteChanged;

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    public class DelegateCommand:DelegateCommandBase
    {
        private readonly Func<bool> _canExecute = ()=>true;
        private readonly Action _execute;

        public DelegateCommand(Action execute)
        {
            _execute = execute;
        }

        public DelegateCommand(Action execute, Func<bool> canExecute):this(execute)
        {
            _canExecute = canExecute;
        }
        public override bool CanExecute(object parameter)
        {
            return _canExecute();
        }

        public override void Execute(object parameter)
        {
            _execute();
        }
    }
    public class DelegateCommand<T>:DelegateCommandBase
    {
        private readonly Func<T,bool> _canExecute = (t)=>true;
        private readonly Action<T> _execute;

        public DelegateCommand(Action<T> execute)
        {
            _execute = execute;
        }

        public DelegateCommand(Action<T> execute, Func<T,bool> canExecute) : this(execute)
        {
            _canExecute = canExecute;
        }
        public override bool CanExecute(object parameter)
        {
            return parameter is T t ? _canExecute(t) : _canExecute(default);
        }

        public override void Execute(object parameter)
        {
            if (parameter is T t)
                _execute(t);
            else
                _execute(default);
        }
    }
}