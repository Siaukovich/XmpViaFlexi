using System;
using FlexiMvvm;
using FlexiMvvm.Bindings;
using FlexiMvvm.Collections;
using FlexiMvvm.Views;
using UIKit;
using VacationsTracker.Core.Presentation.ViewModels.Home;
using VacationsTracker.Core.Resources;
using VacationsTracker.iOS.Views.Home.VacationsTable;

namespace VacationsTracker.iOS.Views.Home
{
    internal class HomeViewController : FlxBindableTabBarController<HomeViewModel>
    {
        private UITableViewObservablePlainSource VacationsSource { get; set; }

        private UIBarButtonItem NewButton { get; } = BarButtonFactory.GetNewButton();

        public new HomeView View
        {
            get => (HomeView)base.View.NotNull();
            set => base.View = value;
        }

        public override void LoadView()
        {
            View = new HomeView();
        }

        public override async void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            NavigationItem.RightBarButtonItem = NewButton;

            //UIView.AnimationsEnabled = false;
            await ViewModel.Refresh();
            //UIView.AnimationsEnabled = true;

            var selection = this.View.VacationsTableView.IndexPathForSelectedRow;
            if (selection != null)
            {
                View.VacationsTableView.DeselectRow(selection, false);
            }
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            VacationsSource = new UITableViewObservablePlainSource(
                View.VacationsTableView,
                _ => VacationItemViewCell.CellId, 
                () => VacationTableHeaderViewCell.CellId,
                () => VacationTableFooterViewCell.CellId)
            {
                Items = ViewModel.Vacations,
                ItemsContext = ViewModel
            };
            
            Title = Strings.HomePage_Title;
            View.VacationsTableView.Source = VacationsSource;

            SetupTabs();
        }

        private void SetupTabs()
        {
            var viewControllers = new UIViewController[ViewModel.TabItems.Count];
            for (var index = 0; index < ViewModel.TabItems.Count; index++)
            {
                viewControllers[index] = CreateTab(ViewModel.TabItems[index]);
            }

            ViewControllers = viewControllers;
        }

        private UIViewController CreateTab(TabItemViewModel tab)
        {
            var viewController = new UIViewController { Title = tab.Title };

            return viewController;
        }

        public override void Bind(BindingSet<HomeViewModel> bindingSet)
        {
            base.Bind(bindingSet);

            bindingSet.Bind(VacationsSource)
                .For(v => v.RowSelectedBinding())
                .To(vm => vm.VacationSelectedCommand);

            bindingSet.Bind(View.VacationsTableView.RefreshControl)
                .For(v => v.BeginRefreshingBinding())
                .To(vm => vm.IsRefreshing);

            bindingSet.Bind(View.VacationsTableView.RefreshControl)
                .For(v => v.EndRefreshingBinding())
                .To(vm => vm.IsRefreshing);

            bindingSet.Bind(View.VacationsTableView.RefreshControl)
                .For(v => v.ValueChangedBinding())
                .To(vm => vm.RefreshCommand);

            bindingSet.Bind(NewButton)
                .For(v => v.NotNull().ClickedBinding())
                .To(vm => vm.CreateNewVacationCommand);
        }
    }
}