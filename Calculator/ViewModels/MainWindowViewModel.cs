using Calculator.Mvvm;

namespace Calculator.ViewModels
{
    public class MainWindowViewModel:ViewModelBase
    {
        public DelegateCommand<object> ButtonPushedCommand { get; set; }

        public string CalculatorText
        {
            get => GetValue<string>();
            set => SetValue(value);
        }

        public string Title { get; set; } = "Cool Calculator";

        public MainWindowViewModel()
        {
            ButtonPushedCommand = new DelegateCommand<object>(ButtonPushed);
        }

        private void ButtonPushed(object obj)
        {
            CalculatorText += obj.ToString();
        }
    }
}
