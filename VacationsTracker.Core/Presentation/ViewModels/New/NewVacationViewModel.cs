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
using VacationsTracker.Core.Presentation.ViewModels.Details;

namespace VacationsTracker.Core.Presentation.ViewModels.New
{
    public class NewVacationViewModel : ViewModelBase, Operations.IViewModelWithOperation
    {
        private readonly INavigationService _navigationService;
        private readonly IVacationsRepository _vacationsRepository;

        private DateTime _startDate;
        private DateTime _endDate;
        private VacationType _type;
        private VacationStatus _status;
        private bool _loading;

        public NewVacationViewModel(
            INavigationService navigationService,
            IVacationsRepository vacationsRepository,
            IOperationFactory operationFactory)
                : base(operationFactory)
        {
            _navigationService = navigationService;
            _vacationsRepository = vacationsRepository;
        }

        public ICommand SaveCommand => CommandProvider.GetForAsync(Save);

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
            set => Set(ref _status, value);
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
                Id = Guid.Empty.ToString(),
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

        protected override async Task InitializeAsync()
        {
            await base.InitializeAsync();

            (StartDate, EndDate, Status, Type) = VacationCellViewModel.GetNew;
        }
    }
}
