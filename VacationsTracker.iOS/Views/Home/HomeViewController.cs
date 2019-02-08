﻿using FlexiMvvm;
using FlexiMvvm.Bindings;
using FlexiMvvm.Collections;
using FlexiMvvm.Views;
using UIKit;
using VacationsTracker.Core.Presentation.ViewModels.Details;
using VacationsTracker.Core.Presentation.ViewModels.Home;
using VacationsTracker.iOS.Views.Home.VacationsTable;

namespace VacationsTracker.iOS.Views.Home
{
    internal class HomeViewController : FlxBindableViewController<HomeViewModel>
    {
        private UITableViewObservablePlainSource VacationsSource { get; set; }

        public new HomeView View
        {
            get => (HomeView)base.View.NotNull();
            set => base.View = value;
        }

        public override void LoadView()
        {
            View = new HomeView();
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
            

            View.VacationsTableView.Source = VacationsSource;
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
        }
    }
}