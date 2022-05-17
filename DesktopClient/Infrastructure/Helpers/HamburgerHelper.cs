﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DesktopClient.Infrastructure.Helpers
{
    public static class HamburgerHelper
    {
        public static void MutateVerbose<TField>(this INotifyPropertyChanged instance
            , ref TField field
            , TField newValue
            , Action<PropertyChangedEventArgs> raise
            , [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<TField>.Default.Equals(field, newValue)) return;
            field = newValue;
            raise?.Invoke(new PropertyChangedEventArgs(propertyName));
        }
    }
}
