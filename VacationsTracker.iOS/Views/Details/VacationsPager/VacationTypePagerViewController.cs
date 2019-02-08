using FlexiMvvm.Bindings;
using FlexiMvvm.Views;
using VacationsTracker.Core.Presentation.ViewModels.Details;

namespace VacationsTracker.iOS.Views.Details.VacationsPager
{
    internal class VacationTypePagerViewController
        : FlxBindableViewController<VacationTypePagerViewModel, VacationTypePagerParameters>
    {
        public VacationTypePagerViewController(VacationTypePagerParameters parameters) : base(parameters)
        {
        }

        //TODO Load View

        public override void Bind(BindingSet<VacationTypePagerViewModel> bindingSet)
        {
            base.Bind(bindingSet);

            // Bindings go here
        }
    }
}