using System.Runtime.Serialization;

namespace VacationsTracker.Core.Domain
{
    public enum VacationStatus
    {
        [EnumMember(Value = "Draft")]
        Draft,

        [EnumMember(Value = "Submitted")]
        Submitted,

        [EnumMember(Value = "Approved")]
        Approved,

        [EnumMember(Value = "InProgress")]
        InProgress,

        [EnumMember(Value = "LeaveWithoutPay")]
        Closed
    }
}