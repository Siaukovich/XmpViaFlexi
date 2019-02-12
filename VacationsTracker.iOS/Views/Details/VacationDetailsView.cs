﻿using System;
using System.Drawing;
using Cirrious.FluentLayouts.Touch;
using FlexiMvvm.Views;
using Foundation;
using UIKit;
using VacationsTracker.Core.Domain;
using VacationsTracker.Core.Resources;
using VacationsTracker.iOS.Themes;

namespace VacationsTracker.iOS.Views.Details
{
    public class VacationDetailsView : LayoutView
    { 
        public UIView VacationsPager { get; private set; }

        public UIPageControl VacationPageControl { get; set; }

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

        public UIDatePicker VacationStartDatePicker { get; private set; }

        public UIDatePicker VacationEndDatePicker { get; private set; }


        protected override void SetupSubviews()
        {
            base.SetupSubviews();

            this.BackgroundColor = AppColors.WhiteColor;

            VacationsPager = new UIView();

            VacationPageControl = new UIPageControl().SetPrimaryPagerStyle();
            VacationPageControl.Pages = Enum.GetValues(typeof(VacationType)).Length;

            AboveDatesSeparator = new UIView().SetSeparator1Style();

            StartDayView = new UIView();

            StartDayLabel = new UILabel().SetDisplay1Style();

            StartMonthLabel = new UILabel().SetDisplay2Style();

            StartYearLabel = new UILabel().SetDisplay3Style();

            EndDayView = new UIView();

            EndDayLabel = new UILabel().SetDisplay4Style();

            EndMonthLabel = new UILabel().SetDisplay5Style();

            EndYearLabel = new UILabel().SetDisplay6Style();

            BelowDatesSeparator = new UIView().SetSeparator1Style();

            StatusSegmentedControl = new UISegmentedControl(
                Strings.VacationStatus_Approved, 
                Strings.VacationStatus_Closed);

            StatusSegmentedControl.SetPrimarySegmentControlStyle();

            VacationStartDatePicker = new UIDatePicker().SetPrimaryDatePickerStyle();
            SetupDatePicker(VacationStartDatePicker);

            VacationEndDatePicker = new UIDatePicker().SetSecondaryDatePickerStyle();
            SetupDatePicker(VacationEndDatePicker);
        }

        protected override void SetupLayout()
        {
            base.SetupLayout();

            this.AddLayoutSubview(VacationsPager)
                .AddLayoutSubview(VacationPageControl)
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
                .AddLayoutSubview(StatusSegmentedControl)
                .AddLayoutSubview(VacationStartDatePicker)
                .AddLayoutSubview(VacationEndDatePicker);
        }

        protected override void SetupLayoutConstraints()
        {
            base.SetupLayoutConstraints();

            this.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            var halfWidth = UIScreen.MainScreen.Bounds.Width / 2;

            this.AddConstraints(
                VacationsPager.AtLeftOf(this),
                VacationsPager.AtTopOf(this),
                VacationsPager.AtRightOf(this),
                VacationsPager.WithRelativeHeight(this, (nfloat)0.45));

            this.AddConstraints(
                VacationPageControl.AtBottomOf(VacationsPager),
                VacationPageControl.WithSameCenterX(VacationsPager));

            this.AddConstraints(
                AboveDatesSeparator.AtLeftOf(this),
                AboveDatesSeparator.Below(VacationPageControl, AppDimens.Inset1X),
                AboveDatesSeparator.AtRightOf(this),
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

            this.AddConstraints(
                VacationStartDatePicker.WithRelativeHeight(this, (nfloat)0.25),
                VacationStartDatePicker.AtBottomOf(this));

            this.AddConstraints(
                VacationEndDatePicker.WithRelativeHeight(this, (nfloat)0.25),
                VacationEndDatePicker.AtBottomOf(this));
        }

        private void SetupDatePicker(UIDatePicker picker)
        {
            picker.Mode = UIDatePickerMode.Date;
            picker.Hidden = true;
        }
    }
}