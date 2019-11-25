using ExpenseControl.UserRegistration.Application.Common;
using System;
using System.Collections.Generic;
using System.Net.Mail;

namespace ExpenseControl.UserRegistration.Domain.AggregateModels.RegisterAggregate
{
    public class User
    {
        public Guid Id { get; }

        public string Email { get; }

        public string Password { get; }

        protected User()
        {
        }

        protected User(string email, string password)
        {
            Id = Guid.NewGuid();
            Email = email;
            Password = password;
        }
        protected User(Guid id ,string email, string password)
        {
            Id = id;
            Email = email;
            Password = password;
        }

        public static Result<User> Create(string email, string password)
        {
            var errorMessages = ValidateParameters(email, password);

            if (errorMessages.Count > 0)
                return Result<User>.Fail(errorMessages);

            var registerUser = new User(email, password);

            return new Result<User>(registerUser);
        }

        public static Result<User> Create(Guid id,string email, string password)
        {
            var errorMessages = ValidateParameters(email, password);           

            if(errorMessages.Count > 0)
                Result<User>.Fail(errorMessages);

            var registerUser = new User(id,email, password);

            return new Result<User>(registerUser);
        }

        private static List<string> ValidateParameters(string email, string password)
        {
            var errorMessages = new List<string>();

            if (string.IsNullOrEmpty(email))
                errorMessages.Add($"{nameof(email)} não pode ser vazio ou nulo.");

            if (!EmailIsValid(email))
                errorMessages.Add($"{nameof(email)} precisa ter um formato valido.");

            if (string.IsNullOrEmpty(password))
                errorMessages.Add($"{nameof(password)} não pode ser vazio ou nulo.");

            return errorMessages;
        }

        private static bool EmailIsValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
