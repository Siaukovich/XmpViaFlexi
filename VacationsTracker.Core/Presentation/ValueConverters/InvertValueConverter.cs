using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using FlexiMvvm.ValueConverters;

namespace VacationsTracker.Core.Presentation.ValueConverters
{
    public class InvertValueConverter : ValueConverter<bool, bool>
    {
        protected override ConversionResult<bool> Convert(bool value, Type targetType, object parameter, CultureInfo culture)
        {
            return ConversionResult<bool>.SetValue(!value);
        }

        protected override ConversionResult<bool> ConvertBack(bool value, Type targetType, object parameter, CultureInfo culture)
        {
            return ConversionResult<bool>.SetValue(!value);
        }
    }
}
