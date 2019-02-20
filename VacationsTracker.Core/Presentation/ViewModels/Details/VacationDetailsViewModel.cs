using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using FlexiMvvm;
using FlexiMvvm.Collections;
using FlexiMvvm.Commands;
using FlexiMvvm.Operations;

using VacationsTracker.Core.DataAccess;
using VacationsTracker.Core.Domain;
using VacationsTracker.Core.Exceptions;
using VacationsTracker.Core.Navigation;
using VacationsTracker.Core.Operations;

namespace VacationsTracker.Core.Presentation.ViewModels.Details
{
    public class VacationDetailsViewModel : ViewModelBase<VacationDetailsParameters>, Operations.IViewModelWithOperation
    {
        private readonly INavigationService _navigationService;
        private readonly IVacationsRepository _vacationsRepository;

        private string _vacationId;

        private DateTime _startDate;
        private DateTime _endDate;
        private VacationType _type;
        private VacationStatus _status;
        private bool _loading;

        public VacationDetailsViewModel(
            INavigationService navigationService,
            IVacationsRepository vacationsRepository,
            IOperationFactory operationFactory)
                : base(operationFactory)
        {
            _navigationService = navigationService;
            _vacationsRepository = vacationsRepository;
        }

        public ICommand SaveCommand => CommandProvider.GetForAsync(Save);

        public ICommand DeleteCommand => CommandProvider.GetForAsync(Delete);

        public RangeObservableCollection<VacationTypePagerParameters> VacationTypes { get; }
            = new RangeObservableCollection<VacationTypePagerParameters>(
                Enum.GetValues(typeof(VacationType))
                    .Cast<VacationType>().Select(t => new VacationTypePagerParameters(t)));

        public DateTime StartDate
        {
            get => _startDate;
            set => Set(ref _startDate, value);
        }

        public DateTime EndDate
        {
            get => _endDate;
            set => Set(ref _endDate, value);
        }

        public VacationType Type
        {
            get => _type;
            set => Set(ref _type, value);
        }

        public VacationStatus Status
        {
            get => _status;
            set => Set( ref _status, value);
        }

        public bool Loading
        {
            get => _loading;
            set => Set(ref _loading, value);
        }

        private Task Save()
        {
            var vacation = new VacationCellViewModel
            {
                Id = _vacationId,
                Start = _startDate,
                End = _endDate,
                Status = _status,
                Type = _type
            };

            return OperationFactory
                  .CreateOperation(OperationContext)
                  .WithInternetConnectionCondition()
                  .WithLoadingNotification()
                  .WithExpressionAsync(token => _vacationsRepository.UpsertVacationAsync(vacation, token))
                  .OnSuccess(() => _navigationService.NavigateBackToHome(this))
                  .OnError<InternetConnectionException>(_ => { })
                  .OnError<Exception>(error => Debug.WriteLine(error.Exception))
                  .ExecuteAsync();
        }

        private Task Delete()
        {
            return OperationFactory
                  .CreateOperation(OperationContext)
                  .WithInternetConnectionCondition()
                  .WithLoadingNotification()
                  .WithExpressionAsync(token => _vacationsRepository.DeleteVacationAsync(_vacationId, token))
                  .OnSuccess(() => _navigationService.NavigateBackToHome(this))
                  .OnError<InternetConnectionException>(_ => { })
                  .OnError<Exception>(error => Debug.WriteLine(error.Exception))
                  .ExecuteAsync();
        }

        protected override async Task InitializeAsync(VacationDetailsParameters parameters)
        {
            await base.InitializeAsync(parameters);

            await OperationFactory
                 .CreateOperation(OperationContext)
                 .WithInternetConnectionCondition()
                 .WithLoadingNotification()
                 .WithExpressionAsync(token =>
                 {
                     var id = parameters.NotNull().VacationId;
                     return _vacationsRepository.GetVacationAsync(id, token);
                 })
                 .OnSuccess(vacation => (_vacationId, StartDate, EndDate, Status, Type) = vacation)
                 .OnError<InternetConnectionException>(_ => { })
                 .OnError<Exception>(error => Debug.WriteLine(error.Exception))
                 .ExecuteAsync();
        }
    }
}
