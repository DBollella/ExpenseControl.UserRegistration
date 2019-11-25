
using System;

namespace ExpenseControl.UserRegistration.Domain.Responses.Commands
{
    public class RegisterUserResponse
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
