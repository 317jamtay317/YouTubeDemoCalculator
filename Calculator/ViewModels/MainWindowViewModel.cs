using Calculator.Core.Calculators;
using Calculator.Mvvm;

namespace Calculator.ViewModels
{
    public class MainWindowViewModel:ViewModelBase
    {
        private readonly ICalculator _calculator;
        public DelegateCommand<object> ButtonPushedCommand { get; set; }
        public DelegateCommand ClearCommand { get; set; }
        public DelegateCommand EqualsCommand { get; set; }

        public string Expression
        {
            get => GetValue<string>();
            set => SetValue(value);
        }

        public string Title { get; set; } = "Cool Calculator";

        public MainWindowViewModel(ICalculator calculator)
        {
            _calculator = calculator;
            ButtonPushedCommand = new DelegateCommand<object>(ButtonPushed);
            ClearCommand = new DelegateCommand(Clear);
            EqualsCommand = new DelegateCommand(Equals, EqualsCanExecute);
        }

        private bool EqualsCanExecute()
        {
            return string.IsNullOrWhiteSpace(Expression) == false;
        }

        private void Equals()
        {
            var value = _calculator.Calculate(Expression);
            Expression = value.ToString();
        }

        private void Clear()
        {
            Expression = null;

            EqualsCommand.RaiseCanExecuteChanged();
        }

        private void ButtonPushed(object obj)
        {
            Expression += obj.ToString();
            EqualsCommand.RaiseCanExecuteChanged();
        }
    }
}
