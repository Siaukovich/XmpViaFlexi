using Android.Content;
using FlexiMvvm;
using FlexiMvvm.Navigation;
using VacationsTracker.Android.Views;
using VacationsTracker.Core.Navigation;
using VacationsTracker.Core.Presentation.ViewModels;

namespace VacationsTracker.Android.Navigation
{
    public class NavigationService : NavigationServiceBase, INavigationService
    {
        public void NavigateToLogin(EntryViewModel fromViewModel)
        {
            var splashScreenActivity = GetActivity<EntryViewModel, SplashScreenActivity>(fromViewModel);
            var loginIntent = new Intent(splashScreenActivity, typeof(LoginActivity));
            splashScreenActivity.NotNull().StartActivity(loginIntent);
        }
    }
}