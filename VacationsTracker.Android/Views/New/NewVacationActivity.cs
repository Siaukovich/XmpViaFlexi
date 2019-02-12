using System;
using Android.App;
using Android.OS;
using Android.Widget;
using FlexiMvvm.Bindings;
using FlexiMvvm.Collections;
using FlexiMvvm.Views;
using FlexiMvvm.Views.V7;
using VacationsTracker.Core.Presentation.ValueConverters;
using VacationsTracker.Core.Presentation.ViewModels.Details;
using VacationsTracker.Core.Presentation.ViewModels.New;
using VacationsTracker.Droid.Views.Details;
using VacationsTracker.Droid.Views.ValueConverters;

namespace VacationsTracker.Droid.Views.New
{
    [Activity(Label = "NewVacationActivity")]
    public class NewVacationActivity : FlxBindableAppCompatActivity<NewVacationViewModel>
    {
        private VacationNewActivityViewHolder ViewHolder { get; set; }

        private FragmentPagerObservableAdapter VacationTypesAdapter { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_vacation_new);

            ViewHolder = new VacationNewActivityViewHolder(this);

            SetTypePagerAdapter();

            SetPagerBottomDots();

            ViewHolder.DateStart.ClickWeakSubscribe(OnVacationStartDayClick);
            ViewHolder.DateEnd.ClickWeakSubscribe(OnVacationEndDayClick);
        }

        private void SetTypePagerAdapter()
        {
            VacationTypesAdapter = new FragmentPagerObservableAdapter(SupportFragmentManager, FragmentsFactory)
            {
                Items = ViewModel.VacationTypes
            };

            ViewHolder.VacationTypePager.Adapter = VacationTypesAdapter;
        }

        private void SetPagerBottomDots()
        {
            var pager = ViewHolder.VacationTypePager;
            var tabLayout = ViewHolder.TabDots;
            tabLayout.SetupWithViewPager(pager);
        }

        public override void Bind(BindingSet<NewVacationViewModel> bindingSet)
        {
            bindingSet.Bind(VacationTypesAdapter)
                .For(v => v.Items)
                .To(vm => vm.VacationTypes);

            bindingSet.Bind(ViewHolder.VacationStartDay)
                .For(v => v.Text)
                .To(vm => vm.StartDate)
                .WithConvertion<DateTimeToDayValueConverter>();

            bindingSet.Bind(ViewHolder.VacationStartMonth)
                .For(v => v.Text)
                .To(vm => vm.StartDate)
                .WithConvertion<DateTimeToMonthValueConverter>();

            bindingSet.Bind(ViewHolder.VacationStartYear)
                .For(v => v.Text)
                .To(vm => vm.StartDate)
                .WithConvertion<DateTimeToYearValueConverter>();

            bindingSet.Bind(ViewHolder.VacationEndDay)
                .For(v => v.Text)
                .To(vm => vm.EndDate)
                .WithConvertion<DateTimeToDayValueConverter>();

            bindingSet.Bind(ViewHolder.VacationEndMonth)
                .For(v => v.Text)
                .To(vm => vm.EndDate)
                .WithConvertion<DateTimeToMonthValueConverter>();

            bindingSet.Bind(ViewHolder.VacationEndYear)
                .For(v => v.Text)
                .To(vm => vm.EndDate)
                .WithConvertion<DateTimeToYearValueConverter>();

            bindingSet.Bind(ViewHolder.StatusRadioGroup)
                .For(v => v.CheckAndCheckedChangeBinding())
                .To(vm => vm.Status)
                .WithConvertion<RadioGroupValueConverter>();

            bindingSet.Bind(ViewHolder.SaveRequestButton)
                .For(v => v.ClickBinding())
                .To(vm => vm.SaveCommand);

            bindingSet.Bind(ViewHolder.VacationTypePager)
                .For(v => v.SetCurrentItemAndPageSelectedBinding())
                .To(vm => vm.Type)
                .WithConvertion<TypeToPagerItemValueConverter>();
        }

        private void OnVacationStartDayClick(object sender, EventArgs args)
        {
            var datePickerFragment = DatePickerFragment.NewInstance(
                ViewModel.StartDate,
                date => ViewModel.StartDate = date,
                date => date > DateTime.Now && date < ViewModel.EndDate,
                OnInvalidDateHandler);

            datePickerFragment.Show(FragmentManager, string.Empty);
        }

        private void OnVacationEndDayClick(object sender, EventArgs args)
        {
            var datePickerFragment = DatePickerFragment.NewInstance(
                ViewModel.EndDate,
                date => ViewModel.EndDate = date,
                date => date > DateTime.Now && date > ViewModel.StartDate,
                OnInvalidDateHandler);

            datePickerFragment.Show(FragmentManager, string.Empty);
        }

        private void OnInvalidDateHandler(DateTime date)
        {
            var t = Toast.MakeText(this, "Invalid date", ToastLength.Short);
            t.Show();
        }

        private Android.Support.V4.App.Fragment FragmentsFactory(object parameters)
        {
            if (parameters is VacationTypePagerParameters vacationTypePagerParameters)
            {
                var bundle = new Bundle();
                bundle.PutViewModelParameters(vacationTypePagerParameters);

                var fragment = new VacationTypeFragment()
                {
                    Arguments = bundle
                };

                return fragment;
            }

            throw new NotSupportedException(nameof(parameters));

        }
    }
}