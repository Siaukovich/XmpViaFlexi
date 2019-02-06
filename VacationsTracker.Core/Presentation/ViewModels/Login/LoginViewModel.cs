using System.Threading.Tasks;
using FlexiMvvm;
using FlexiMvvm.Commands;
using VacationsTracker.Core.Navigation;

namespace VacationsTracker.Core.Presentation.ViewModels.Login
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        private bool _validCredentials = true;

        public LoginViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public ICommand LoginCommand => CommandProvider.GetForAsync(Login);

        public string UserLogin { get; set; }

        public string UserPassword { get; set; }

        public bool ValidCredentials
        {
            get => _validCredentials;
            set => Set(ref _validCredentials, value);
        }

        private async Task Login()
        {
            // TODO login operation

            await Task.Delay(500);

            //ValidCredentials = (UserLogin == "A") && (UserPassword == "B");

            if (ValidCredentials)
            {
                _navigationService.NavigateToHome(this);
            }
        }
    }
}
