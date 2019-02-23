using System.Runtime.Serialization;

namespace VacationsTracker.Core.Domain
{
    public enum VacationStatus
    {
        Draft = 0,
        Submitted = 1,
        Approved = 2,
        InProgress = 3,
        Closed = 4
    }
}