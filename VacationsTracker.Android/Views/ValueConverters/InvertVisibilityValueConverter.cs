using System;
using System.Globalization;
using Android.Views;
using FlexiMvvm.ValueConverters;

namespace VacationsTracker.Droid.Views.ValueConverters
{
    class InvertVisibilityValueConverter : ValueConverter<bool, ViewStates>
    {
        protected override ConversionResult<ViewStates> Convert(bool value, Type targetType, object parameter, CultureInfo culture)
        {
            var state = value ? ViewStates.Invisible : ViewStates.Visible;

            return ConversionResult<ViewStates>.SetValue(state);
        }
    }
}