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

        private bool _validCredentials = true;
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

        public bool ValidCredentials
        {
            get => _validCredentials;
            set => Set(ref _validCredentials, value);
        }

        public bool Loading
        {
            get => _loading;
            set => Set(ref _loading, value);
        }

        private Task Login()
        {
            ValidCredentials = true;

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
                  .OnError<AuthenticationException>(_ => ValidCredentials = false)
                  .OnError<InvalidCredentialsException>(_ => ValidCredentials = false)
                  .OnError<InternetConnectionException>(_ => { })
                  .OnError<Exception>(error => Debug.WriteLine(error.Exception))
                  .ExecuteAsync();
        }
    }
}
