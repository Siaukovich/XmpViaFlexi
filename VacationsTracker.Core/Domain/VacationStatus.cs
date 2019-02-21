using System.Runtime.Serialization;

namespace VacationsTracker.Core.Domain
{
    public enum VacationStatus
    {
        [EnumMember(Value = "Approved")]
        Approved,

        [EnumMember(Value = "LeaveWithoutPay")]
        Closed
    }
}