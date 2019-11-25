using MediatR;

namespace ExpenseControl.UserRegistration.API.Controllers
{
    internal class RegisterUserCommand : IRequest<object>
    {
        private string email;
        private string password;

        public RegisterUserCommand(string email, string password)
        {
            this.email = email;
            this.password = password;
        }
    }
}