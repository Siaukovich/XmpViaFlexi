using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;
using FlexiMvvm;
using FlexiMvvm.Collections;
using FlexiMvvm.Commands;
using FlexiMvvm.Operations;
using VacationsTracker.Core.DataAccess;
using VacationsTracker.Core.Domain;
using VacationsTracker.Core.Exceptions;
using VacationsTracker.Core.Navigation;
using VacationsTracker.Core.Presentation.ViewModels.Details;
using VacationsTracker.Core.Operations;
using ICommand = FlexiMvvm.Commands.ICommand;

namespace VacationsTracker.Core.Presentation.ViewModels.Home
{
    public class HomeViewModel : ViewModelBase, Operations.IViewModelWithOperation
    {
        private readonly INavigationService _navigationService;
        private readonly IVacationsRepository _vacationsRepository;
        private DateTime _refreshedDateTime;
        private bool _loading;

        public HomeViewModel(
            INavigationService navigationService,
            IVacationsRepository vacationsRepository,
            IOperationFactory operationFactory)
                : base(operationFactory)
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

        public bool Loading
        {
            get => _loading;
            set => Set(ref _loading, value);
        }

        public ICommand<VacationCellViewModel> VacationSelectedCommand => CommandProvider.Get<VacationCellViewModel>(VacationSelected);

        public ICommand CreateNewVacationCommand => CommandProvider.Get(CreateNewVacation);

        public ICommand<NavigationMenuItem> FilterVacationsCommand => CommandProvider.GetForAsync<NavigationMenuItem>(FilterVacations);

        public ICommand RefreshCommand => CommandProvider.GetForAsync(Refresh);

        private Task FilterVacations(NavigationMenuItem item)
        {
            return OperationFactory
                  .CreateOperation(OperationContext)
                  .WithInternetConnectionCondition()
                  .WithLoadingNotification()
                  .WithExpressionAsync(token => _vacationsRepository.GetVacationsAsync(token))
                  .OnSuccess(vacations => FilterVacations(item, vacations))
                  .OnError<InternetConnectionException>(_ => { })
                  .OnError<AuthenticationException>(ex => Debug.WriteLine(ex))
                  .ExecuteAsync();
        }

        private void FilterVacations(NavigationMenuItem item, IEnumerable<VacationCellViewModel> vacations)
        {
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

        public Task Refresh()
        {
            return OperationFactory
                  .CreateOperation(OperationContext)
                  .WithInternetConnectionCondition()
                  .WithLoadingNotification()
                  .WithExpressionAsync(token => ReloadVacations())
                  .OnSuccess(() => RefreshedDateTime = DateTime.Now)
                  .OnError<InternetConnectionException>(_ => { })
                  .OnError<AuthenticationException>(ex => Debug.WriteLine(ex))
                  .ExecuteAsync();
        }

        private async Task ReloadVacations()
        {
            Vacations.Clear();

            await LoadVacations();
        }

        private Task LoadVacations()
        {
            return OperationFactory
                  .CreateOperation(OperationContext)
                  .WithInternetConnectionCondition()
                  .WithLoadingNotification()
                  .WithExpressionAsync(token => _vacationsRepository.GetVacationsAsync(token))
                  .OnSuccess(vacations =>
                  {
                      VacationsAddRange(vacations);
                      RefreshedDateTime = DateTime.Now;
                  })
                  .OnError<InternetConnectionException>(_ => { })
                  .OnError<AuthenticationException>(ex => Debug.WriteLine(ex))
                  .ExecuteAsync();
        }

        private void VacationsAddRange(IEnumerable<VacationCellViewModel> vacations)
        {
            if (Vacations.Any())
            {
                Vacations.Last().SeparatorVisible = true;
            }

            var vacationList = vacations.ToList();
            if (vacationList.Any())
            {
                vacationList.Last().SeparatorVisible = false;
            }

            Vacations.AddRange(vacationList);
        }
    }
}
