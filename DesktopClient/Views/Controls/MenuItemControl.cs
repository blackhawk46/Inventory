using MahApps.Metro.Controls;
using System;
using System.ComponentModel;
using DesktopClient.Infrastructure.Helpers;

namespace DesktopClient.Views.Controls
{
    public class MenuItemControl : HamburgerMenuItem, INotifyPropertyChanged
    {
        private object _content;
        public object Content
        {
            get => _content;
            set => this.MutateVerbose(ref _content, value, RaisePropertyChanged());
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private Action<PropertyChangedEventArgs> RaisePropertyChanged() => args => PropertyChanged?.Invoke(this, args);
    }
}
