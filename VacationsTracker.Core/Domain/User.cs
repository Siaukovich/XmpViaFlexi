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
            Login = login;
            Password = password;
        }

        public void ValidateCredentials()
        {
            if (Login == null || Password == null)
            {
                throw new InvalidCredentialsException();
            }
        }
    }
}