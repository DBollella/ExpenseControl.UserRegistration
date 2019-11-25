using ExpenseControl.UserRegistration.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ExpenseControl.UserRegistration.Infra.IoC
{
    public static class ServicesContainerEx
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IRegisterUserServices, RegisterUserServices>();
        }
    }
}
