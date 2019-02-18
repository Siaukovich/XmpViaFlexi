using System;
using System.Linq;
using System.Threading.Tasks;
using FlexiMvvm;
using FlexiMvvm.Collections;
using FlexiMvvm.Commands;
using VacationsTracker.Core.DataAccess;
using VacationsTracker.Core.Domain;
using VacationsTracker.Core.Navigation;
using VacationsTracker.Core.Presentation.ViewModels.Details;

namespace VacationsTracker.Core.Presentation.ViewModels.New
{
    public class NewVacationViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IVacationsRepository _vacationsRepository;

        private string _vacationId;

        private DateTime _startDate;
        private DateTime _endDate;
        private VacationType _type;
        private VacationStatus _status;

        public NewVacationViewModel(
            INavigationService navigationService,
            IVacationsRepository vacationsRepository)
        {
            _navigationService = navigationService;
            _vacationsRepository = vacationsRepository;
        }


        public ICommand SaveCommand => CommandProvider.Get(Save);

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

        private async void Save()
        {
            var vacation = new VacationCellViewModel
            {
                Id = _vacationId,
                Start = _startDate,
                End = _endDate,
                Status = _status,
                Type = _type
            };

            await _vacationsRepository.UpsertVacationAsync(vacation);
            _navigationService.NavigateBackToHome(this);
        }

        protected override async Task InitializeAsync()
        {
            await base.InitializeAsync();

            var vacation = VacationCellViewModel.GetNew;

            (_vacationId, StartDate, EndDate, Status, Type) = vacation;
        }
    }
}
