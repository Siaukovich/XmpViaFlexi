using System.Runtime.Serialization;

namespace VacationsTracker.Core.Domain
{
    public enum VacationType
    {
        Undefined = 0,
        Regular = 1,
        Sick = 2,
        Exceptional = 3,
        Overtime = 4,
        LeaveWithoutPay = 5
    }
}