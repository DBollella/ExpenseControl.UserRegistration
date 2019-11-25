using ExpenseControl.UserRegistration.Application.Common;
using ExpenseControl.UserRegistration.Domain.Responses.Commands;
using MediatR;

namespace ExpenseControl.UserRegistration.Application.Commands
{
    public class RegisterUserCommand : IRequest<Result<RegisterUserResponse>>
    {
        public RegisterUserCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public string Email { get; }
        public string Password { get; }
    }
}
