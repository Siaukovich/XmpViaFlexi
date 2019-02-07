using FlexiMvvm;
using FlexiMvvm.Bindings;
using FlexiMvvm.Views;
using VacationsTracker.Core.Presentation.ValueConverters;
using VacationsTracker.Core.Presentation.ViewModels.Details;

namespace VacationsTracker.iOS.Views.Details
{
    public class VacationDetailsViewController : FlxBindableViewController<VacationDetailsViewModel, VacationDetailsParameters>
    {
        public new VacationDetailsView View
        {
            get => (VacationDetailsView)base.View.NotNull();
            set => base.View = value;
        }

        public override void LoadView()
        {
            View = new VacationDetailsView();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

        }

        public override void Bind(BindingSet<VacationDetailsViewModel> bindingSet)
        {
            base.Bind(bindingSet);

            bindingSet.Bind(View.StartDayLabel)
                .For(v => v.Text)
                .To(vm => vm.Vacation.Start)
                .WithConvertion<DateTimeToDayValueConverter>();

            bindingSet.Bind(View.StartMonthLabel)
                .For(v => v.Text)
                .To(vm => vm.Vacation.Start)
                .WithConvertion<DateTimeToMonthValueConverter>();

            bindingSet.Bind(View.StartYearLabel)
                .For(v => v.Text)
                .To(vm => vm.Vacation.Start)
                .WithConvertion<DateTimeToYearValueConverter>();

            bindingSet.Bind(View.EndDayLabel)
                .For(v => v.Text)
                .To(vm => vm.Vacation.End)
                .WithConvertion<DateTimeToDayValueConverter>();

            bindingSet.Bind(View.EndMonthLabel)
                .For(v => v.Text)
                .To(vm => vm.Vacation.End)
                .WithConvertion<DateTimeToMonthValueConverter>();

            bindingSet.Bind(View.EndYearLabel)
                .For(v => v.Text)
                .To(vm => vm.Vacation.End)
                .WithConvertion<DateTimeToYearValueConverter>();
        }

        public VacationDetailsViewController(VacationDetailsParameters parameters) : base(parameters)
        {
            
        }
    }
}