using System;
using System.Globalization;
using FlexiMvvm.ValueConverters;
using VacationsTracker.Core.Domain;

namespace VacationsTracker.Droid.Views.ValueConverters
{
    public class NavigationMenuItemValueConverter : ValueConverter<NavigationMenuItem, int>
    {
        protected override ConversionResult<NavigationMenuItem> ConvertBack(int resId, Type targetType, object parameter, CultureInfo culture)
        {
            NavigationMenuItem item;
            switch (resId)
            {
                case Resource.Id.navigation_all:
                    item = NavigationMenuItem.All;
                    break;

                case Resource.Id.navigation_open:
                    item = NavigationMenuItem.Open;
                    break;

                case Resource.Id.navigation_closed:
                    item = NavigationMenuItem.Closed;
                    break;

                default:
                    throw new ArgumentException("Invalid resource id", nameof(resId));
            }

            return ConversionResult<NavigationMenuItem>.SetValue(item);
        }
    }
}