using Android.Content;

using FlexiMvvm;
using FlexiMvvm.Navigation;
using FlexiMvvm.Views;

using VacationsTracker.Core.Navigation;
using VacationsTracker.Core.Presentation.ViewModels;
using VacationsTracker.Core.Presentation.ViewModels.Details;
using VacationsTracker.Core.Presentation.ViewModels.Home;
using VacationsTracker.Core.Presentation.ViewModels.Login;
using VacationsTracker.Core.Presentation.ViewModels.New;
using VacationsTracker.Droid.Views;
using VacationsTracker.Droid.Views.Details;
using VacationsTracker.Droid.Views.Home;
using VacationsTracker.Droid.Views.Login;
using VacationsTracker.Droid.Views.New;

namespace VacationsTracker.Droid.Navigation
{
    public class NavigationService : NavigationServiceBase, INavigationService
    {
        public void NavigateToLogin(EntryViewModel fromViewModel)
        {
            var splashScreenActivity = GetActivity<EntryViewModel, SplashScreenActivity>(fromViewModel);
            var loginIntent = new Intent(splashScreenActivity, typeof(LoginActivity));
            splashScreenActivity.NotNull().StartActivity(loginIntent);
        }

        public void NavigateBackToLogin(HomeViewModel fromViewModel)
        {
            var homeActivity = GetActivity<HomeViewModel, HomeActivity>(fromViewModel);
            var loginIntent = new Intent(homeActivity, typeof(LoginActivity));
            loginIntent.AddFlags(ActivityFlags.ClearTask | ActivityFlags.ClearTop | ActivityFlags.NewTask);
            homeActivity.NotNull().StartActivity(loginIntent);
        }

        public void NavigateToHome(LoginViewModel fromViewModel)
        {
            var loginActivity = GetActivity<LoginViewModel, LoginActivity>(fromViewModel);
            var homeIntent = new Intent(loginActivity, typeof(HomeActivity));
            homeIntent.AddFlags(ActivityFlags.ClearTask | ActivityFlags.ClearTop | ActivityFlags.NewTask);
            loginActivity.NotNull().StartActivity(homeIntent);
        }

        public void NavigateToVacationDetails(HomeViewModel fromViewModel, VacationDetailsParameters parameters)
        {
            var homeActivity = GetActivity<HomeViewModel, HomeActivity>(fromViewModel);
            var detailsIntent = new Intent(homeActivity, typeof(VacationDetailsActivity));
            detailsIntent.PutViewModelParameters(parameters);
            homeActivity.NotNull().StartActivity(detailsIntent);
        }

        public void NavigateBackToHome(VacationDetailsViewModel fromViewModel)
        {
            var vacationDetailsActivity = GetActivity<VacationDetailsViewModel, VacationDetailsActivity>(fromViewModel);
            vacationDetailsActivity.NotNull().Finish();
        }

        public void NavigateToNewVacation(HomeViewModel fromViewModel)
        {
            var homeActivity = GetActivity<HomeViewModel, HomeActivity>(fromViewModel);
            var newVacationIntent = new Intent(homeActivity, typeof(NewVacationActivity));
            homeActivity.NotNull().StartActivity(newVacationIntent);
        }

        public void NavigateBackToHome(NewVacationViewModel fromViewModel)
        {
            var vacationDetailsActivity = GetActivity<NewVacationViewModel, NewVacationActivity>(fromViewModel);
            vacationDetailsActivity.NotNull().Finish();
        }
    }
}