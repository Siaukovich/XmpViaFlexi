using System.Runtime.Serialization;

namespace VacationsTracker.Core.DTO
{
    public enum BaseClassCode
    {
        [EnumMember(Value = "OK")]
        OK,

        [EnumMember(Value = "ValidationFailed")]
        ValidationFailed,

        [EnumMember(Value = "NotFound")]
        NotFound
    }
}