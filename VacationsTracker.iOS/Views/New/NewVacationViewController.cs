using System;
using FlexiMvvm;
using FlexiMvvm.Bindings;
using FlexiMvvm.Collections;
using FlexiMvvm.Views;
using UIKit;
using VacationsTracker.Core.Presentation.ValueConverters;
using VacationsTracker.Core.Presentation.ViewModels.Details;
using VacationsTracker.Core.Presentation.ViewModels.New;
using VacationsTracker.Droid.Views.ValueConverters;
using VacationsTracker.iOS.Helpers;
using VacationsTracker.iOS.Views.Details;
using VacationsTracker.iOS.Views.Details.VacationsTypePager;
using VacationsTracker.iOS.Views.ValueConverters;

namespace VacationsTracker.iOS.Views.New
{
    public class NewVacationViewController
        : FlxBindableViewController<NewVacationViewModel>
    {
        private UIPageViewController VacationsPageViewController { get; set; }

        private UIPageViewControllerObservableDataSource VacationsDataSource { get; set; }

        private UIBarButtonItem SaveButton { get; } = BarButtonFactory.GetSaveButton();

        public new NewVacationView View
        {
            get => (NewVacationView)base.View.NotNull();
            set => base.View = value;
        }

        public override void LoadView()
        {
            View = new NewVacationView();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Title = "New request";

            VacationsPageViewController = new UIPageViewController(
                UIPageViewControllerTransitionStyle.Scroll,
                UIPageViewControllerNavigationOrientation.Horizontal);

            VacationsDataSource = new UIPageViewControllerObservableDataSource(
                VacationsPageViewController,
                PagerFactory);

            this.AddChildViewControllerAndView(VacationsPageViewController, View.VacationsPager);

            VacationsDataSource.CurrentItemIndexChanged +=
                (sender, args) => View.VacationPageControl.CurrentPage = args.Index;

            VacationsPageViewController.DataSource = VacationsDataSource;

            var tapGesture = new UITapGestureRecognizer(OnStartDayViewTap);
            View.StartDayView.AddGestureRecognizer(tapGesture);
            View.VacationStartDatePicker.ValueChangedWeakSubscribe(StartDateValueChangedHandler);

            tapGesture = new UITapGestureRecognizer(OnEndDayViewTap);
            View.EndDayView.AddGestureRecognizer(tapGesture);
            View.VacationEndDatePicker.ValueChangedWeakSubscribe(StartEndValueChangedHandler);
        }

        private void OnStartDayViewTap()
        {
            View.VacationEndDatePicker.Hidden = true;

            View.VacationStartDatePicker.Date = ViewModel.Vacation.Start.ToNSDate();
            View.VacationStartDatePicker.Hidden = false;
        }

        private void OnEndDayViewTap()
        {
            View.VacationStartDatePicker.Hidden = true;

            View.VacationEndDatePicker.Date = ViewModel.Vacation.End.ToNSDate();
            View.VacationEndDatePicker.Hidden = false;
        }

        private void StartDateValueChangedHandler(object sender, EventArgs args)
        {
            if (sender is UIDatePicker picker)
            {
                var date = (DateTime)picker.Date;
                ViewModel.Vacation.Start = date;
            }
        }
        private void StartEndValueChangedHandler(object sender, EventArgs args)
        {
            if (sender is UIDatePicker picker)
            {
                var date = (DateTime)picker.Date;
                ViewModel.Vacation.End = date;
            }
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            NavigationItem.RightBarButtonItem = SaveButton;
        }

        public override void Bind(BindingSet<NewVacationViewModel> bindingSet)
        {
            base.Bind(bindingSet);

            bindingSet.Bind(VacationsDataSource)
                .For(v => v.Items)
                .To(vm => vm.VacationTypes);

            bindingSet.Bind(VacationsDataSource)
                .For(v => v.CurrentItemIndexAndCurrentItemIndexChangedBinding())
                .To(vm => vm.Vacation.Type)
                .WithConvertion<TypeToPagerItemValueConverter>();

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

            bindingSet.Bind(View.StatusSegmentedControl)
                .For(v => v.SelectedSegmentAndValueChangedBinding())
                .To(vm => vm.Vacation.Status)
                .WithConvertion<VacationStatusSegmentedControlConverter>();

            bindingSet.Bind(SaveButton)
                .For(v => v.NotNull().ClickedBinding())
                .To(vm => vm.SaveCommand);
        }

        private UIViewController PagerFactory(object parameters)
        {
            if (parameters is VacationTypePagerParameters pagerParameters)
            {
                return new VacationTypePagerViewController(pagerParameters);
            }

            throw new ArgumentException(nameof(parameters));
        }
    }
}