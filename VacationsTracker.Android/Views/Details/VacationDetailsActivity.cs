using Android.App;
using Android.OS;
using Android.Widget;
using FlexiMvvm.Bindings;
using FlexiMvvm.Views.V7;
using VacationsTracker.Core.Domain;
using VacationsTracker.Core.Presentation.ValueConverters;
using VacationsTracker.Core.Presentation.ViewModels.Details;
using VacationsTracker.Droid.Views.ValueConverters;

namespace VacationsTracker.Droid.Views.Details
{
    [Activity(Label = "VacationDetailsActivity")]
    public class VacationDetailsActivity 
        : FlxBindableAppCompatActivity<VacationDetailsViewModel, VacationDetailsParameters>
    {
        private VacationDetailsActivityViewHolder ViewHolder { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_vacation_details);

            ViewHolder = new VacationDetailsActivityViewHolder(this);
        }

        public override void Bind(BindingSet<VacationDetailsViewModel> bindingSet)
        {
            bindingSet.Bind(ViewHolder.VacationStartDay)
                .For(v => v.Text)
                .To(vm => vm.VacationStart)
                .WithConvertion<DateTimeToDayValueConverter>();

            bindingSet.Bind(ViewHolder.VacationStartMonth)
                .For(v => v.Text)
                .To(vm => vm.VacationStart)
                .WithConvertion<DateTimeToMonthValueConverter>();

            bindingSet.Bind(ViewHolder.VacationStartYear)
                .For(v => v.Text)
                .To(vm => vm.VacationStart)
                .WithConvertion<DateTimeToYearValueConverter>();

            bindingSet.Bind(ViewHolder.VacationEndDay)
                .For(v => v.Text)
                .To(vm => vm.VacationEnd)
                .WithConvertion<DateTimeToDayValueConverter>();

            bindingSet.Bind(ViewHolder.VacationEndMonth)
                .For(v => v.Text)
                .To(vm => vm.VacationEnd)
                .WithConvertion<DateTimeToMonthValueConverter>();

            bindingSet.Bind(ViewHolder.VacationEndYear)
                .For(v => v.Text)
                .To(vm => vm.VacationEnd)
                .WithConvertion<DateTimeToYearValueConverter>();

            bindingSet.Bind(ViewHolder.ClosedRadio)
                .For(v => v.Checked)
                .To(vm => vm.VacationStatus)
                .WithConvertion<VacationStatusToClosedRadioValueConverter>();

            bindingSet.Bind(ViewHolder.ApprovedRadio)
                .For(v => v.Checked)
                .To(vm => vm.VacationStatus)
                .WithConvertion<VacationStatusToApprovedRadioValueConverter>();
        }
    }
}