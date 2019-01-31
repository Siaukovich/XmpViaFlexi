using System;
using System.Linq;
using System.Threading.Tasks;
using FlexiMvvm;
using FlexiMvvm.Collections;
using FlexiMvvm.Commands;
using VacationsTracker.Core.DataAccess;
using VacationsTracker.Core.Domain;
using VacationsTracker.Core.Navigation;

namespace VacationsTracker.Core.Presentation.ViewModels.Details
{
    public class VacationDetailsViewModel : ViewModelBase<VacationDetailsParameters>
    {
        private readonly INavigationService _navigationService;
        private readonly IVacationsRepository _vacationsRepository;

        public VacationDetailsViewModel(
            INavigationService navigationService,
            IVacationsRepository vacationsRepository)
        {
            _navigationService = navigationService;
            _vacationsRepository = vacationsRepository;
        }

        public VacationCellViewModel Vacation { get; set; }

        public ICommand SaveCommand => CommandProvider.Get(Save);

        public RangeObservableCollection<VacationTypePagerParameters> VacationTypes { get; }
            = new RangeObservableCollection<VacationTypePagerParameters>(
                Enum.GetValues(typeof(VacationType))
                    .Cast<VacationType>().Select(t => new VacationTypePagerParameters(t)));

        private async void Save()
        {
            await _vacationsRepository.UpdateVacationAsync(Vacation);
            _navigationService.NavigateBackToHome(this);
        }

        protected override async Task InitializeAsync(VacationDetailsParameters parameters)
        {
            await base.InitializeAsync(parameters);

            Vacation = await _vacationsRepository.GetVacationAsync(parameters.NotNull().VacationId);
        }
    }
}
