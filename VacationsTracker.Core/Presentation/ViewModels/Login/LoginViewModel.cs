using System;
using System.Diagnostics;
using System.Security.Authentication;
using System.Threading.Tasks;

using FlexiMvvm;
using FlexiMvvm.Commands;
using FlexiMvvm.Operations;

using VacationsTracker.Core.DataAccess;
using VacationsTracker.Core.Domain;
using VacationsTracker.Core.Domain.Exceptions;
using VacationsTracker.Core.Exceptions;
using VacationsTracker.Core.Navigation;
using VacationsTracker.Core.Operations;
using VacationsTracker.Core.Resources;

namespace VacationsTracker.Core.Presentation.ViewModels.Login
{
    public class LoginViewModel : ViewModelBase, Operations.IViewModelWithOperation
    {
        private readonly INavigationService _navigationService;
        private readonly IUserRepository _userRepository;

        private bool _errorOccured = false;
        private bool _loading;
        private string _errorMessage;

        public LoginViewModel(
            INavigationService navigationService, 
            IUserRepository userRepository, 
            IOperationFactory operationFactory) 
            : base(operationFactory)
        {
            _navigationService = navigationService;
            _userRepository = userRepository;
        }

        public ICommand LoginCommand => CommandProvider.GetForAsync(Login);

        public string UserLogin { get; set; }

        public string UserPassword { get; set; }

        public string ErrorMessage
        {
            get => _errorMessage;
            set => Set(ref _errorMessage, value);
        }

        public bool ErrorOccured
        {
            get => _errorOccured;
            set => Set(ref _errorOccured, value);
        }

        public bool Loading
        {
            get => _loading;
            set => Set(ref _loading, value);
        }

        private Task Login()
        {
            ErrorOccured = false;

            return OperationFactory
                  .CreateOperation(OperationContext)
                  .WithLoadingNotification()
                  .WithInternetConnectionCondition()
                  .WithExpressionAsync(token =>
                  {
                      var user = new User(UserLogin, UserPassword);

                      user.ValidateCredentials();

                      return _userRepository.AuthorizeAsync(user, token);
                  })
                  .OnSuccess(() => _navigationService.NavigateToHome(this))
                  .OnError<AuthenticationException>(_ => SetError(Strings.LoginPage_InvalidCredentials))
                  .OnError<EmptyPasswordException>(_ => SetError(Strings.LoginPage_InvalidPassword))
                  .OnError<EmptyLoginException>(_ => SetError(Strings.LoginPage_InvalidLogin))
                  .OnError<InternetConnectionException>(_ => SetError(Strings.LoginPage_NoInternet))
                  .OnError<Exception>(error => SetError(Strings.LoginPage_UnknownError))
                  .ExecuteAsync();
        }

        private void SetError(string message)
        {
            ErrorMessage = message;
            ErrorOccured = true;
        }
    }
}
