using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Calculator.Annotations;

namespace Calculator.Mvvm
{
    public abstract class ViewModelBase:BindableBase
    {

        private Dictionary<string, object> _values = new Dictionary<string, object>();
        protected T GetValue<T>([CallerMemberName] string propertyName = null)
        {
            if (_values.ContainsKey(propertyName))
            {
                return (T)_values[propertyName];
            }

            return default;
        }

        protected void SetValue<T>(T value, [CallerMemberName] string propertyName = null)
        {
            if (_values.ContainsKey(propertyName))
            {
                _values[propertyName] = value;
            }
            else
            {
                _values.Add(propertyName, value);
            }
            OnPropertyChanged(propertyName);
        }
    }

    public class BindableBase:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}