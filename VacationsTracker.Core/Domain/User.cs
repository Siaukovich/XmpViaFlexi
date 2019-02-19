using System;
using VacationsTracker.Core.Domain.Exceptions;

namespace VacationsTracker.Core.Domain
{
    public class User
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public User(string login, string password)
        {
            Login = login ?? throw new ArgumentNullException(nameof(login));
            Password = password ?? throw new ArgumentNullException(nameof(password));
        }

        public void ValidateCredentials()
        {
            if (string.IsNullOrWhiteSpace(Login) || string.IsNullOrWhiteSpace(Password))
            {
                throw new InvalidCredentialsException();
            }
        }
    }
}