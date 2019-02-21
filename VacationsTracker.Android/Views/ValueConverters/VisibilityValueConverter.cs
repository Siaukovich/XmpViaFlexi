using System;
using System.Globalization;
using Android.Views;
using FlexiMvvm.ValueConverters;

namespace VacationsTracker.Droid.Views.ValueConverters
{
    public class VisibilityValueConverter : ValueConverter<bool, ViewStates>
    {
        protected override ConversionResult<ViewStates> Convert(bool visible, Type targetType, object parameter, CultureInfo culture)
        {
            var state = visible ? ViewStates.Visible : ViewStates.Invisible;

            return ConversionResult<ViewStates>.SetValue(state);
        }
    }
}