using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseControl.UserRegistration.Domain.AggregateModels.RegisterAggregate;
using ExpenseControl.UserRegistration.Domain.Repository;

namespace ExpenseControl.UserRegistration.Infra.Repository
{
    public class UserRegistrationRepository : IUserRegistrationRepository
    {
        private string _connectionString;
        private List<User> users = new List<User>();

        public async Task<User> GetUserById(Guid id)
        {
            try
            {
                User user = null;

                //using (var conn = new SqlConnection(_connectionString))
                //{
                if(users != null)
                    user = users.Where(x => x.Id == id).FirstOrDefault();

                return user;
                //}
            }
            catch (Exception ex)
            {
                //Logger.LogError(ex, $"Falha ao consultar Usuario para o id: {id}");
                throw;
            }
        }

        public async Task<IReadOnlyList<User>> GetUsers()
        {
            try
            {
                //using (var conn = new SqlConnection(_connectionString))
                //{
                var user = users.Select(x => x).ToList();
                return user.ToList<User>().AsReadOnly();
                //}
            }
            catch (Exception ex)
            {
                //Logger.LogError(ex, $"Falha ao consultar Usuario para o id: {id}");
                throw;
            }
        }

        public async Task ResgisterUser(User user)
        {
            try
            {
                users.Add(user);
            }
            catch (Exception ex)
            {
                throw;
            }  
        }
    }
}
