using FlexiMvvm;
using VacationsTracker.Core.Domain;

namespace VacationsTracker.Core.Presentation.ViewModels.Details
{
    public class VacationTypePagerParameters : ViewModelBundleBase
    {
        public VacationTypePagerParameters(VacationType type)
        {
            VacationType = type;
        }

        public VacationType VacationType
        {
            get => (VacationType)Bundle.GetInt();
            set => Bundle.SetInt((int)value);
        }
    }
}