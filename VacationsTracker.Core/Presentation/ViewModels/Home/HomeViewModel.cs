using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using FlexiMvvm;
using FlexiMvvm.Collections;
using VacationsTracker.Core.DataAccess;
using VacationsTracker.Core.Navigation;

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

        protected override async Task InitializeAsync()
        {
            await base.InitializeAsync();

            var vacations = await _vacationsRepository.GetVacationsAsync();

            var list = vacations.ToList();
            if (list.Count != 0)
            {
                list[list.Count - 1].SeparatorVisible = false;
            }

            Vacations.AddRange(list);
        }
    }
}
