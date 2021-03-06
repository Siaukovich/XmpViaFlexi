﻿using System;

namespace VacationsTracker.Core.Domain
{
    public static class VacationTypeExtensions
    {
        public static string ToFriendlyString(this VacationType type)
        {
            switch (type)
            {
                case VacationType.Regular:
                    return "Regular";
                case VacationType.Sick:
                    return "Sick days";
                case VacationType.Exceptional:
                    return "Exceptional leave";
                case VacationType.Overtime:
                    return "Overtime";
                case VacationType.LeaveWithoutPay:
                    return "Leave without pay";
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}