using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ExpenseControl.UserRegistration.Application.Common;
using ExpenseControl.UserRegistration.Domain.AggregateModels.RegisterAggregate;
using ExpenseControl.UserRegistration.Domain.Repository;
using ExpenseControl.UserRegistration.Domain.Responses.Commands;

namespace ExpenseControl.UserRegistration.Domain.Services
{
    public class RegisterUserServices : IRegisterUserServices
    {
        private IUserRegistrationRepository _userRegistrationRepository;

        public RegisterUserServices(IUserRegistrationRepository userRegistrationRepository)
        {
            _userRegistrationRepository = userRegistrationRepository;
        }

        public async Task<Result<GetUserResponse>> GetUser(Guid id)
        {
            try
            {
                var userRegistration = await _userRegistrationRepository.GetUserById(id);

                if (userRegistration == null)
                    return Result<GetUserResponse>.Fail("Usuario nao localizado");

                var getUserResponse = new GetUserResponse()
                {
                    Id = userRegistration.Id,
                    Email = userRegistration.Email,
                    Password = userRegistration.Password
                };

                return Result<GetUserResponse>.Ok(getUserResponse);
            }
            catch (Exception)
            {
                return Result<GetUserResponse>.Fail("Erro ao consultar usuario");
            }
        }

        public async Task<Result<GetUsersResponse>> GetUsers(User user)
        {
            try
            {
                var userRegistration = await _userRegistrationRepository.GetUsers();

                if (userRegistration == null)
                    return Result<GetUsersResponse>.Fail("Usuario nao localizado");

                var getUserResponse = new GetUsersResponse()
                {
                    users = userRegistration
                };

                return Result<GetUsersResponse>.Ok(getUserResponse);
            }
            catch (Exception)
            {
                return Result<GetUsersResponse>.Fail("Erro ao consultar usuarios");
            }
        }


        public async Task<Result<RegisterUserResponse>> RegisterUser(User user)
        {
            if (user is null)
                return Result<RegisterUserResponse>.Fail($"{nameof(user)} não deve ser nulo");

            try
            {
                var userRegistration = await _userRegistrationRepository.GetUserById(user.Id);

                if (userRegistration != null)
                    return Result<RegisterUserResponse>.Fail("Usuario já existente");

                await _userRegistrationRepository.ResgisterUser(user);

                return Result<RegisterUserResponse>.Ok(new RegisterUserResponse() { Email = user.Email, Id = user.Id, Password = user.Password });
            }
            catch (Exception ex)
            {
                return Result<RegisterUserResponse>.Fail("Erro ao registrar usuario");
            }
        }
    }
}
