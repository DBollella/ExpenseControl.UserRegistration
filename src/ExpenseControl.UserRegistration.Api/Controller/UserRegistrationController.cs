using ExpenseControl.UserRegistration.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ExpenseControl.UserRegistration.Api.Controller
{
    [Route("api/[controller]")]  
    [ApiController]    
    public class UserRegistrationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserRegistrationController(IMediator mediator)
        {
            _mediator = mediator;
        }  

        [HttpPost]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.Accepted)]
        [ProducesResponseType(typeof(string[]), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Post([FromBody] RequestUserRegistration request)
        {
            var response = await _mediator.Send(new RegisterUserCommand(request.Email, request.Password));
                      
            if (response.IsFailure)
                return BadRequest(response.Messages);

            return Ok(response);

        }
    }

    public class RequestUserRegistration
    {

        public string Email { get; set; }
        public string Password { get; set; }
    }
}
