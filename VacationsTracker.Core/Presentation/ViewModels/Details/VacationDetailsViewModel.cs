﻿using System;
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

        //public VacationType VacationType { get; set; }

        //public DateTime VacationStart { get; set; }

        //public DateTime VacationEnd { get; set; }

        //public VacationStatus VacationStatus
        //{
        //    get => Cell.Status;
        //    set =>
        //}

        public VacationCellViewModel Vacation { get; set; }

        public ICommand SaveCommand => CommandProvider.Get(Save);

        public RangeObservableCollection<VacationTypePagerParameters> VacationTypes { get; } 
            = new RangeObservableCollection<VacationTypePagerParameters>
            {
                new VacationTypePagerParameters { VacationType = VacationType.Regular },
                new VacationTypePagerParameters { VacationType = VacationType.Overtime },
                new VacationTypePagerParameters { VacationType = VacationType.SickDays },
                new VacationTypePagerParameters { VacationType = VacationType.ExceptionalLeave },
                new VacationTypePagerParameters { VacationType = VacationType.LeaveWithoutPay },
            };

        private async void Save()
        {
            await _vacationsRepository.UpdateVacationAsync(Vacation);
            _navigationService.NavigateBackToHome(this);
        }

        protected override async Task InitializeAsync(VacationDetailsParameters parameters)
        {
            await base.InitializeAsync(parameters);

            var vacation = await _vacationsRepository.GetVacationAsync(parameters.NotNull().VacationId);

            Vacation = vacation;

            //VacationType = vacation.Type;
            //VacationStart = vacation.Start;
            //VacationEnd = vacation.End;
            //VacationStatus = vacation.Status;
        }
    }
}
