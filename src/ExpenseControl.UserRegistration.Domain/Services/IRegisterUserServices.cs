using ExpenseControl.UserRegistration.Application.Common;
using ExpenseControl.UserRegistration.Domain.Responses.Commands;
using ExpenseControl.UserRegistration.Domain.AggregateModels.RegisterAggregate;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ExpenseControl.UserRegistration.Domain.Services
{
    public interface IRegisterUserServices
    {
        Task<Result<RegisterUserResponse>> RegisterUser(User user);

        Task<Result<GetUsersResponse>> GetUsers(User user);

        Task<Result<GetUserResponse>> GetUser(Guid id);
    }

    public class GetUserResponse
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class GetUsersResponse
    {
        public IReadOnlyList<User> users { get; set; }
    }
}
