using FlexiMvvm;
using FlexiMvvm.Ioc;
using VacationsTracker.Core.DataAccess;
using VacationsTracker.Core.Navigation;
using VacationsTracker.Core.Presentation.ViewModels;
using VacationsTracker.Core.Presentation.ViewModels.Details;
using VacationsTracker.Core.Presentation.ViewModels.Home;
using VacationsTracker.Core.Presentation.ViewModels.Login;
using VacationsTracker.Core.Presentation.ViewModels.New;

namespace VacationsTracker.Core.Presentation
{
    public class VacationsTrackerViewModelLocator : ViewModelLocatorBase
    {
        private readonly IDependencyProvider _dependencyProvider;

        public VacationsTrackerViewModelLocator(IDependencyProvider dependencyProvider)
        {
            _dependencyProvider = dependencyProvider;
        }

        protected override void SetupFactory(ViewModelFactory factory)
        {
            factory.Register(() => new EntryViewModel(_dependencyProvider.Get<INavigationService>()));

            factory.Register(() => new LoginViewModel(
                _dependencyProvider.Get<INavigationService>(), 
                _dependencyProvider.Get<IUserRepository>()));

            factory.Register(() => new HomeViewModel(
                _dependencyProvider.Get<INavigationService>(),
                _dependencyProvider.Get<IVacationsRepository>()));

            factory.Register(() => new VacationDetailsViewModel(
                _dependencyProvider.Get<INavigationService>(),
                _dependencyProvider.Get<IVacationsRepository>()));

            factory.Register(() => new VacationTypePagerViewModel());

            factory.Register(() => new NewVacationViewModel(
                _dependencyProvider.Get<INavigationService>(),
                _dependencyProvider.Get<IVacationsRepository>()));
        }
    }
}
