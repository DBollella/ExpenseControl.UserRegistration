using ExpenseControl.UserRegistration.Application.Commands;
using ExpenseControl.UserRegistration.Application.Common;
using ExpenseControl.UserRegistration.Application.Handlers;
using ExpenseControl.UserRegistration.Domain.Responses.Commands;
using MediatR;
using Microsoft.Extensions.DependencyInjection;


namespace ExpenseControl.UserRegistration.Infra.IoC
{
    public static class HandlersContainerEx
    {
        public static void RegisterHandlers(this IServiceCollection services)
        {
            services.AddMediatR(typeof(RegisterUserCommandHandler).Assembly);

            services.AddScoped(
                 typeof(IRequestHandler<RegisterUserCommand, Result<RegisterUserResponse>>),
                 typeof(RegisterUserCommandHandler));
        }
    }
}
