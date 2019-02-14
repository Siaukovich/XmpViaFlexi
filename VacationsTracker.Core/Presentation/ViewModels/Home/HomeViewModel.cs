using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlexiMvvm;
using FlexiMvvm.Collections;
using FlexiMvvm.Commands;
using VacationsTracker.Core.DataAccess;
using VacationsTracker.Core.Domain;
using VacationsTracker.Core.Navigation;
using VacationsTracker.Core.Presentation.ViewModels.Details;
using VacationsTracker.Core.Resources;
using ICommand = FlexiMvvm.Commands.ICommand;

namespace VacationsTracker.Core.Presentation.ViewModels.Home
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IVacationsRepository _vacationsRepository;
        private DateTime _refreshedDateTime;
        private bool _isRefreshing;

        public HomeViewModel(
            INavigationService navigationService,
            IVacationsRepository vacationsRepository)
        {
            _navigationService = navigationService;
            _vacationsRepository = vacationsRepository;
        }

        public RangeObservableCollection<VacationCellViewModel> Vacations { get; } = new RangeObservableCollection<VacationCellViewModel>();

        public RangeObservableCollection<TabItemViewModel> TabItems { get; } = new RangeObservableCollection<TabItemViewModel>();

        public DateTime RefreshedDateTime
        {
            get => _refreshedDateTime;
            set => Set(ref _refreshedDateTime, value);
        }

        public bool IsRefreshing
        {
            get => _isRefreshing;
            set => Set(ref _isRefreshing, value);
        }

        public ICommand<VacationCellViewModel> VacationSelectedCommand => CommandProvider.Get<VacationCellViewModel>(VacationSelected);

        public ICommand CreateNewVacationCommand => CommandProvider.Get(CreateNewVacation);

        public ICommand<NavigationMenuItem> FilterVacationsCommand => CommandProvider.GetForAsync<NavigationMenuItem>(FilterVacations);

        public ICommand RefreshCommand => CommandProvider.GetForAsync(Refresh);

        private async Task FilterVacations(NavigationMenuItem item)
        {
            var vacations = await _vacationsRepository.GetVacationsAsync();

            switch (item)
            {
                case NavigationMenuItem.All:
                    break;

                case NavigationMenuItem.Open:
                    vacations = vacations.Where(v => v.Status == VacationStatus.Approved);
                    break;

                case NavigationMenuItem.Closed:
                    vacations = vacations.Where(v => v.Status == VacationStatus.Closed);
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(item), item, null);
            }

            Vacations.Clear();
            VacationsAddRange(vacations);
        }

        private void VacationSelected(VacationCellViewModel vacationCellViewModel)
        {
            var parameters = new VacationDetailsParameters(vacationCellViewModel.Id);
            _navigationService.NavigateToVacationDetails(this, parameters);
        }

        private void CreateNewVacation()
        {
            _navigationService.NavigateToNewVacation(this);
        }

        public async Task Refresh()
        {
            IsRefreshing = true;

            await Task.Delay(1000);

            await ReloadVacations();

            IsRefreshing = false;

            RefreshedDateTime = DateTime.Now;
        }

        protected override async Task InitializeAsync()
        {
            await base.InitializeAsync();

            await LoadVacations();

            RefreshedDateTime = DateTime.Now;

            TabItems.AddRange(new []
            {
                new TabItemViewModel(Strings.NavigationView_All, FilterVacationsCommand),
                new TabItemViewModel(Strings.NavigationView_Open, FilterVacationsCommand),
                new TabItemViewModel(Strings.NavigationView_Closed, FilterVacationsCommand),
            });
        }

        private async Task ReloadVacations()
        {
            Vacations.Clear();

            await LoadVacations();
        }

        private async Task LoadVacations()
        {
            var vacations = await _vacationsRepository.GetVacationsAsync();

            VacationsAddRange(vacations);
        }

        private void VacationsAddRange(IEnumerable<VacationCellViewModel> vacations)
        {
            //if (Vacations.Any())
            //{
            //    Vacations.Last().SeparatorVisible = true;
            //}

            foreach (var v in vacations)
            {
                v.SeparatorVisible = true;
            }

            if (vacations.Any())
            {
                vacations.Last().SeparatorVisible = false;
            }

            Vacations.AddRange(vacations);
        }
    }
}
