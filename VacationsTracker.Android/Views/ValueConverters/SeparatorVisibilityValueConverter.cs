using System;
using System.Globalization;
using Android.Views;
using FlexiMvvm.ValueConverters;

namespace VacationsTracker.Droid.Views.ValueConverters
{
    class SeparatorVisibilityValueConverter : ValueConverter<bool, ViewStates>
    {
        protected override ConversionResult<ViewStates> Convert(bool isVisible, Type targetType, object parameter, CultureInfo culture)
        {
            var visibility = isVisible ? ViewStates.Visible : ViewStates.Invisible;

            return ConversionResult<ViewStates>.SetValue(visibility);
        }
    }
}