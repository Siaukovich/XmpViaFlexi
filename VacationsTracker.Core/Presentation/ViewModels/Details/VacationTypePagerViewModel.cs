using FlexiMvvm;
using VacationsTracker.Core.Domain;

namespace VacationsTracker.Core.Presentation.ViewModels.Details
{
    public class VacationTypePagerViewModel : ViewModelBase<VacationTypePagerParameters>
    {
        public VacationType VacationType { get; private set; }

        protected override void Initialize(VacationTypePagerParameters parameters)
        {
            base.Initialize(parameters);

            VacationType = parameters.NotNull().VacationType;
        }
    }
}