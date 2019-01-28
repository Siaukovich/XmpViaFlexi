using System;
using System.Globalization;
using FlexiMvvm.ValueConverters;

namespace VacationsTracker.Core.Presentation.ValueConverters
{
    public class DurationValueConverter : ValueConverter<(DateTime, DateTime), string>
    {
        protected override ConversionResult<string> Convert((DateTime, DateTime) value, Type targetType, object parameter, CultureInfo culture)
        {
            const string DURATION_FORMAT = "{0} - {1}";

            var start = value.Item1.ToString("dd MMM").ToUpper(CultureInfo.CurrentCulture);
            var end = value.Item2.ToString("dd MMM").ToUpper(CultureInfo.CurrentCulture);

            var result = string.Format(DURATION_FORMAT, start, end);

            return ConversionResult<string>.SetValue(result);
        }
    }
}