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

namespace VacationsTracker.Core.Presentation.ViewModels.Login
{
    public class LoginViewModel : ViewModelBase, Operations.IViewModelWithOperation
    {
        private readonly INavigationService _navigationService;
        private readonly IUserRepository _userRepository;

        private bool _invalidCredentials = false;
        private bool _loading;

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

        public bool InvalidCredentials
        {
            get => _invalidCredentials;
            set => Set(ref _invalidCredentials, value);
        }

        public bool Loading
        {
            get => _loading;
            set => Set(ref _loading, value);
        }

        private Task Login()
        {
            InvalidCredentials = false;

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
                  .OnError<AuthenticationException>(_ => InvalidCredentials = true)
                  .OnError<InvalidCredentialsException>(_ => InvalidCredentials = true)
                  .OnError<InternetConnectionException>(_ => { })
                  .OnError<Exception>(error => Debug.WriteLine(error.Exception))
                  .ExecuteAsync();
        }
    }
}
