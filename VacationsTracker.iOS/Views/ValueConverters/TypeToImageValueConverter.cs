using System;
using System.Globalization;
using FlexiMvvm.ValueConverters;
using UIKit;
using VacationsTracker.Core.Domain;

namespace VacationsTracker.iOS.Views.ValueConverters
{
    internal class TypeToImageValueConverter : ValueConverter<VacationType, UIImage>
    {
        protected override ConversionResult<UIImage> Convert(VacationType value, Type targetType, object parameter, CultureInfo culture)
        {
            UIImage image;

            switch (value)
            {
                case VacationType.Regular:
                    image = UIImage.FromBundle("IconRequestGreen");
                    break;
                case VacationType.Sick:
                    image = UIImage.FromBundle("IconRequestPlum");
                    break;
                case VacationType.Exceptional:
                    image = UIImage.FromBundle("IconRequestGray");
                    break;
                case VacationType.Overtime:
                    image = UIImage.FromBundle("IconRequestBlue");
                    break;
                case VacationType.LeaveWithoutPay:
                    image = UIImage.FromBundle("IconRequestDark");
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(value), value, null);
            }

            return ConversionResult<UIImage>.SetValue(image);
        }
    }
}