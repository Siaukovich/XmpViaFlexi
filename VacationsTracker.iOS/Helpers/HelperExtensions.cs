﻿using System;
using Foundation;

namespace VacationsTracker.iOS.Helpers
{
    public static class HelperExtensions
    {
        public static NSDate ToNSDate(this DateTime date)
        {
            if (date.Kind == DateTimeKind.Unspecified)
            {
                date = DateTime.SpecifyKind(date, DateTimeKind.Utc);
            }

            return (NSDate)date;
        }
    }
}