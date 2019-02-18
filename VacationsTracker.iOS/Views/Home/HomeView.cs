using Cirrious.FluentLayouts.Touch;
using FlexiMvvm.Views;
using UIKit;
using VacationsTracker.iOS.Themes;
using VacationsTracker.iOS.Views.Home.VacationsTable;

namespace VacationsTracker.iOS.Views.Home
{
    internal class HomeView : LayoutView
    {
        public UITableView VacationsTableView { get; private set; }

        public UITabBar VacationsTabBar { get; private set; }

        protected override void SetupSubviews()
        {
            base.SetupSubviews();

            BackgroundColor = AppColors.WhiteColor;

            VacationsTableView = new UITableView();
            VacationsTableView.RegisterClassForCellReuse(
                typeof(VacationItemViewCell),
                VacationItemViewCell.CellId);

            VacationsTableView.RegisterClassForHeaderFooterViewReuse(
                typeof(VacationTableFooterViewCell),
                VacationTableFooterViewCell.CellId);

            VacationsTableView.RegisterClassForHeaderFooterViewReuse(
                typeof(VacationTableHeaderViewCell),
                VacationTableHeaderViewCell.CellId);

            VacationsTableView.RefreshControl = new UIRefreshControl();

            VacationsTabBar = new UITabBar();

            //VacationsTableView.AllowsSelection = true;
            VacationsTableView.SeparatorStyle = UITableViewCellSeparatorStyle.None;
        }

        protected override void SetupLayout()
        {
            base.SetupLayout();

            this.AddLayoutSubview(VacationsTableView)
                .AddLayoutSubview(VacationsTabBar);
        }

        protected override void SetupLayoutConstraints()
        {
            base.SetupLayoutConstraints();

            this.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            this.AddConstraints(
                VacationsTableView.AtLeftOf(this),
                VacationsTableView.AtTopOf(this),
                VacationsTableView.AtRightOf(this),
                VacationsTableView.Above(VacationsTabBar)
            );

            this.AddConstraints(VacationsTabBar.AtBottomOf(this));
        }
    }
}