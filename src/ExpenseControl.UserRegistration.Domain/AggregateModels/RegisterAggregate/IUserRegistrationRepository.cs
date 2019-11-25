using ExpenseControl.UserRegistration.Domain.AggregateModels.RegisterAggregate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseControl.UserRegistration.Domain.Repository
{
    public interface IUserRegistrationRepository
    {
        Task ResgisterUser(User user);

        Task<User> GetUserById(Guid id);

        Task<IReadOnlyList<User>> GetUsers();
    }
}
