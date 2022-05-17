using System;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DesktopClient.Infrastructure.Helpers
{
    public class Bindable : INotifyPropertyChanged, INotifyPropertyChanging
    {
        private readonly ConcurrentDictionary<string, object> _properties = new ConcurrentDictionary<string, object>();

        public event PropertyChangedEventHandler PropertyChanged;
        public event PropertyChangingEventHandler PropertyChanging;

        private bool CallPropertyChangeEvent { get; } = true;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        protected void OnPropertyChanging([CallerMemberName] string propertyName = null) =>
            PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(propertyName));

        protected T Get<T>(T defValue = default(T), [CallerMemberName] string name = null) =>
            !string.IsNullOrEmpty(name) && _properties.TryGetValue(name, out var value)
                ? (T)value
                : defValue;

        protected bool Set(object value, [CallerMemberName] string name = null, Action afterChangedAction = null)
        {
            if (string.IsNullOrEmpty(name))
                return false;

            var isExists = _properties.TryGetValue(name, out var getValue);
            if (isExists && Equals(value, getValue))
                return false;

            if (CallPropertyChangeEvent)
                OnPropertyChanging(name);

            _properties.AddOrUpdate(name, value, (s, o) => value);

            if (CallPropertyChangeEvent)
                OnPropertyChanged(name);

            afterChangedAction?.Invoke();
            return true;
        }
    }
}