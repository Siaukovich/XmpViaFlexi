using System.Drawing;
using Cirrious.FluentLayouts.Touch;
using FlexiMvvm.Views;
using UIKit;
using VacationsTracker.iOS.Themes;

namespace VacationsTracker.iOS.Views.Details
{
    public class VacationDetailsView : LayoutView
    { 
        public UIView Pager { get; private set; }

        public UIView AboveDatesSeparator { get; private set; }
        
        public UIView StartDayView { get; private set; }

        public UILabel StartDayLabel{ get; private set; }

        public UILabel StartMonthLabel { get; private set; }

        public UILabel StartYearLabel { get; private set; }

        public UIView EndDayView { get; private set; }

        public UILabel EndDayLabel { get; private set; }

        public UILabel EndMonthLabel { get; private set; }

        public UILabel EndYearLabel { get; private set; }

        public UIView BelowDatesSeparator { get; private set; }

        public UISegmentedControl StatusSegmentedControl { get; private set; }

        protected override void SetupSubviews()
        {
            base.SetupSubviews();

            this.BackgroundColor = AppColors.WhiteColor;

            Pager = new UIView().SetMainBackgroundColorStyle();

            AboveDatesSeparator = new UIView().SetSeparatorStyle(AppColors.LightBlueColor);

            StartDayView = new UIView();

            StartDayLabel = new UILabel().SetTextMainColorStyle().SetBoldFontSize(60);

            StartMonthLabel = new UILabel().SetTextMainColorStyle().SetBoldFontSize(30);

            StartYearLabel = new UILabel().SetTextMainColorStyle().SetBoldFontSize(25);

            EndDayView = new UIView();

            EndDayLabel = new UILabel().SetsSecondaryColorTextStyle().SetBoldFontSize(60);

            EndMonthLabel = new UILabel().SetsSecondaryColorTextStyle().SetBoldFontSize(30);

            EndYearLabel = new UILabel().SetsSecondaryColorTextStyle().SetBoldFontSize(25);

            BelowDatesSeparator = new UIView().SetSeparatorStyle(AppColors.LightBlueColor);

            StatusSegmentedControl = new UISegmentedControl("Approved", "Closed");
            StatusSegmentedControl.TintColor = AppColors.LightGreenColor;
        }

        protected override void SetupLayout()
        {
            base.SetupLayout();

            this.AddLayoutSubview(Pager)
                .AddLayoutSubview(AboveDatesSeparator)
                .AddLayoutSubview(StartDayView)
                .AddLayoutSubview(StartDayLabel)
                .AddLayoutSubview(StartMonthLabel)
                .AddLayoutSubview(StartYearLabel)
                .AddLayoutSubview(EndDayView)
                .AddLayoutSubview(EndDayLabel)
                .AddLayoutSubview(EndMonthLabel)
                .AddLayoutSubview(EndYearLabel)
                .AddLayoutSubview(BelowDatesSeparator)
                .AddLayoutSubview(StatusSegmentedControl);
        }

        protected override void SetupLayoutConstraints()
        {
            base.SetupLayoutConstraints();

            this.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            var halfWidth = UIScreen.MainScreen.Bounds.Width / 2;

            this.AddConstraints(
                Pager.AtLeftOf(this),
                Pager.AtTopOf(this),
                Pager.AtRightOf(this),
                Pager.Height().EqualTo(200));

            this.AddConstraints(
                AboveDatesSeparator.Below(Pager, AppDimens.Inset1X),
                AboveDatesSeparator.Height().EqualTo(AppDimens.DefaultSeparatorSize));

            this.AddConstraints(
                StartDayView.AtLeftOf(this),
                StartDayView.Below(AboveDatesSeparator),
                StartDayView.Width().EqualTo(halfWidth));

            this.AddConstraints(
                StartDayLabel.AtLeftOf(StartDayView, AppDimens.Inset1X),
                StartDayLabel.AtTopOf(StartDayView),
                StartDayLabel.AtBottomOf(StartDayView));

            this.AddConstraints(
                StartMonthLabel.ToRightOf(StartDayLabel, AppDimens.InsetHalf),
                StartMonthLabel.AtTopOf(StartDayLabel, AppDimens.Inset1X));

            this.AddConstraints(
                StartYearLabel.WithSameRight(StartMonthLabel),
                StartYearLabel.AtBottomOf(StartDayLabel, AppDimens.Inset1X));

            this.AddConstraints(
                EndDayView.ToRightOf(StartDayView),
                EndDayView.WithSameTop(StartDayView),
                EndDayView.AtRightOf(this),
                EndDayView.WithSameBottom(StartDayView));

            this.AddConstraints(
                EndDayLabel.ToLeftOf(EndMonthLabel, AppDimens.InsetHalf),
                EndDayLabel.WithSameTop(StartDayLabel),
                EndDayLabel.WithSameBottom(StartDayLabel));

            this.AddConstraints(
                EndMonthLabel.AtRightOf(EndDayView, AppDimens.Inset1X),
                EndMonthLabel.WithSameTop(StartMonthLabel));

            this.AddConstraints(
                EndYearLabel.WithSameTop(StartYearLabel),
                EndYearLabel.WithSameRight(EndMonthLabel),
                EndYearLabel.AtBottomOf(EndDayLabel, AppDimens.Inset1X));

            this.AddConstraints(
                BelowDatesSeparator.AtLeftOf(this),
                BelowDatesSeparator.Below(EndDayView),
                BelowDatesSeparator.AtRightOf(this),
                BelowDatesSeparator.Height().EqualTo(AppDimens.DefaultSeparatorSize));

            this.AddConstraints(
                StatusSegmentedControl.Below(BelowDatesSeparator, AppDimens.Inset2X),
                StatusSegmentedControl.WithSameCenterX(this));
        }
    }
}