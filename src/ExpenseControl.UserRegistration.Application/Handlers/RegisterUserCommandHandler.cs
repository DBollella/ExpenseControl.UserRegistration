using ExpenseControl.UserRegistration.Application.Commands;
using ExpenseControl.UserRegistration.Application.Common;
using ExpenseControl.UserRegistration.Domain.Responses.Commands;
using ExpenseControl.UserRegistration.Domain.AggregateModels.RegisterAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ExpenseControl.UserRegistration.Domain.Services;

namespace ExpenseControl.UserRegistration.Application.Handlers
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Result<RegisterUserResponse>>
    {
        private readonly IMediator _mediator;        
        private readonly IRegisterUserServices _registerUserService;

        public RegisterUserCommandHandler(IMediator mediator, IRegisterUserServices registerUserService)
        {
            _mediator = mediator;
            _registerUserService = registerUserService;
        }

        public async Task<Result<RegisterUserResponse>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {

            var user = User.Create(request.Email, request.Password);

            if (user.IsFailure)
                return Result<RegisterUserResponse>.Fail(user.Messages);

            var registerUserResponse = await _registerUserService.RegisterUser(user.Value);

            if (registerUserResponse.IsFailure)
                return Result<RegisterUserResponse>.Fail("Registro de Usuario Falhou");

            return Result<RegisterUserResponse>.Ok(registerUserResponse.Value);
        }
    }
}
