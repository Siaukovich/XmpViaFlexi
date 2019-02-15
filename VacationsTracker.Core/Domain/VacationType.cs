using System.Runtime.Serialization;

namespace VacationsTracker.Core.Domain
{
    public enum VacationType
    {
        [EnumMember(Value = "Undefined")]
        Undefined,

        [EnumMember(Value = "Regular")]
        Regular,

        [EnumMember(Value = "Sick")]
        Sick,

        [EnumMember(Value = "Exceptional")]
        Exceptional,

        [EnumMember(Value = "Overtime")]
        Overtime,

        [EnumMember(Value = "LeaveWithoutPay")]
        LeaveWithoutPay
    }
}