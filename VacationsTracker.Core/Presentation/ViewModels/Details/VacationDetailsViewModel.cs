using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FlexiMvvm;
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

        public VacationType VacationType { get; set; }

        public DateTime VacationStart { get; set; }

        public DateTime VacationEnd { get; set; }

        public VacationStatus VacationStatus { get; set; }

        protected override async Task InitializeAsync(VacationDetailsParameters parameters)
        {
            await base.InitializeAsync(parameters);

            var vacation = await _vacationsRepository.GetVacationAsync(parameters.VacationId);

            VacationType = vacation.Type;
            VacationStart = vacation.Start;
            VacationEnd = vacation.End;
            VacationStatus = vacation.Status;
        }
    }
}
