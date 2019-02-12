using System;
using CoreGraphics;
using FlexiMvvm;
using FlexiMvvm.Bindings;
using FlexiMvvm.Collections;
using FlexiMvvm.Views;
using Foundation;
using UIKit;
using VacationsTracker.Core.Presentation.ValueConverters;
using VacationsTracker.Core.Presentation.ViewModels.Details;
using VacationsTracker.Droid.Views.ValueConverters;
using VacationsTracker.iOS.Helpers;
using VacationsTracker.iOS.Themes;
using VacationsTracker.iOS.Views.Details.VacationsTypePager;
using VacationsTracker.iOS.Views.ValueConverters;

namespace VacationsTracker.iOS.Views.Details
{
    public class VacationDetailsViewController
        : FlxBindableViewController<VacationDetailsViewModel, VacationDetailsParameters>
    {
        private UIPageViewController VacationsPageViewController { get; set; }

        private UIPageViewControllerObservableDataSource VacationsDataSource { get; set; }

        private UIBarButtonItem SaveButton { get; } = BarButtonFactory.GetSaveButton();

        public new VacationDetailsView View
        {
            get => (VacationDetailsView)base.View.NotNull();
            set => base.View = value;
        }

        public VacationDetailsViewController(VacationDetailsParameters parameters) : base(parameters)
        {
        }

        public override void LoadView()
        {
            View = new VacationDetailsView();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Title = "Request";

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

            tapGesture = new UITapGestureRecognizer(OnEndDayViewTap);
            View.EndDayView.AddGestureRecognizer(tapGesture);
        }

        private void OnStartDayViewTap()
        {
            View.VacationEndDatePicker.Hidden = true;
            View.VacationStartDatePicker.Hidden = false;
        }

        private void OnEndDayViewTap()
        {
            View.VacationStartDatePicker.Hidden = true;
            View.VacationEndDatePicker.Hidden = false;
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            NavigationItem.RightBarButtonItem = SaveButton;
        }

        public override void Bind(BindingSet<VacationDetailsViewModel> bindingSet)
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
                .To(vm => vm.StartDate)
                .WithConvertion<DateTimeToDayValueConverter>();

            bindingSet.Bind(View.StartMonthLabel)
                .For(v => v.Text)
                .To(vm => vm.StartDate)
                .WithConvertion<DateTimeToMonthValueConverter>();

            bindingSet.Bind(View.StartYearLabel)
                .For(v => v.Text)
                .To(vm => vm.StartDate)
                .WithConvertion<DateTimeToYearValueConverter>();

            bindingSet.Bind(View.EndDayLabel)
                .For(v => v.Text)
                .To(vm => vm.EndDate)
                .WithConvertion<DateTimeToDayValueConverter>();

            bindingSet.Bind(View.EndMonthLabel)
                .For(v => v.Text)
                .To(vm => vm.EndDate)
                .WithConvertion<DateTimeToMonthValueConverter>();

            bindingSet.Bind(View.EndYearLabel)
                .For(v => v.Text)
                .To(vm => vm.EndDate)
                .WithConvertion<DateTimeToYearValueConverter>();

            bindingSet.Bind(View.StatusSegmentedControl)
                .For(v => v.SelectedSegmentAndValueChangedBinding())
                .To(vm => vm.Vacation.Status)
                .WithConvertion<VacationStatusSegmentedControlConverter>();

            bindingSet.Bind(SaveButton)
                .For(v => v.NotNull().ClickedBinding())
                .To(vm => vm.SaveCommand);

            bindingSet.Bind(View.VacationStartDatePicker)
                .For(v => v.DateAndValueChangedBinding())
                .To(vm => vm.StartDate);

            bindingSet.Bind(View.VacationEndDatePicker)
                .For(v => v.DateAndValueChangedBinding())
                .To(vm => vm.EndDate);
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