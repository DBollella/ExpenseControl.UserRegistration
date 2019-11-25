using ExpenseControl.UserRegistration.Domain.Repository;
using ExpenseControl.UserRegistration.Infra.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace ExpenseControl.UserRegistration.Infra.IoC
{
    public static class RepositoriesContainerEx
    {
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddTransient<IUserRegistrationRepository, UserRegistrationRepository>();
        }
    }
}
