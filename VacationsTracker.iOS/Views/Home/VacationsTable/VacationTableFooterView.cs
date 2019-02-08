using Cirrious.FluentLayouts.Touch;
using FlexiMvvm.Views;
using UIKit;
using VacationsTracker.iOS.Themes;

namespace VacationsTracker.iOS.Views.Home.VacationsTable
{
    internal class VacationTableFooterView : LayoutView
    {
        protected override void SetupLayout()
        {
            base.SetupLayout();

            this.BackgroundColor = AppColors.GrayColor;
        }

        protected override void SetupLayoutConstraints()
        {
            base.SetupLayoutConstraints();

            this.AddConstraints(this.Height().EqualTo(AppDimens.DefaultSeparatorSize));
        }
    }
}