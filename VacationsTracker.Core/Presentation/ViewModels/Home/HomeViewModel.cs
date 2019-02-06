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
using ICommand = FlexiMvvm.Commands.ICommand;

namespace VacationsTracker.Core.Presentation.ViewModels.Home
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IVacationsRepository _vacationsRepository;
        private DateTime _refreshedDateTime = DateTime.Now;

        public HomeViewModel(
            INavigationService navigationService,
            IVacationsRepository vacationsRepository)
        {
            _navigationService = navigationService;
            _vacationsRepository = vacationsRepository;
        }

        public RangeObservableCollection<VacationCellViewModel> Vacations { get; } = new RangeObservableCollection<VacationCellViewModel>();

        public DateTime RefreshedDateTime
        {
            get => _refreshedDateTime;
            set => Set(ref _refreshedDateTime, value);
        }

        public ICommand<VacationCellViewModel> VacationSelectedCommand => CommandProvider.Get<VacationCellViewModel>(VacationSelected);

        public ICommand CreateNewVacationCommand => CommandProvider.Get(CreateNewVacation);

        public ICommand<NavigationMenuItem> FilterVacationsCommand => CommandProvider.Get<NavigationMenuItem>(FilterVacations);

        private async void FilterVacations(NavigationMenuItem item)
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
            await ReloadVacations();
        }

        protected override async Task InitializeAsync()
        {
            await base.InitializeAsync();

            await LoadVacations();
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
            if (Vacations.Any())
            {
                Vacations.Last().SeparatorVisible = true;
            }

            if (vacations.Any())
            {
                vacations.Last().SeparatorVisible = false;
            }

            Vacations.AddRange(vacations);
        }
    }
}
