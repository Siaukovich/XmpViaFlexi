﻿using Cirrious.FluentLayouts.Touch;
using FlexiMvvm.Views;
using UIKit;
using VacationsTracker.iOS.Themes;

namespace VacationsTracker.iOS.Views.Home.VacationsTable
{
    internal class VacationTableFooterView : LayoutView
    {
        public UIView Separator { get; private set; }

        protected override void SetupSubviews()
        {
            base.SetupSubviews();

            this.BackgroundColor = AppColors.WhiteColor;

            Separator = new UIView().SetSeparator2Style();
        }

        protected override void SetupLayout()
        {
            base.SetupLayout();

            this.AddLayoutSubview(Separator);
        }

        protected override void SetupLayoutConstraints()
        {
            base.SetupLayoutConstraints();

            this.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            this.AddConstraints(
                Separator.AtLeftOf(this),
                Separator.AtRightOf(this),
                Separator.Height().EqualTo(AppDimens.DefaultSeparatorSize));
        }
    }
}