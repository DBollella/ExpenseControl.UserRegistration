using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ExpenseControl.UserRegistration.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExpenseControl.UserRegistration.API.Controllers
{
    [Produces("application/json")]
    [Route("")]
    public class UserRegistrationController : Controller
    {
        private readonly IMediator _mediator;

        public UserRegistrationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.Accepted)]
        [ProducesResponseType(typeof(string[]), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Post([FromBody] RequestUserRegistration request)
        {
            var response = await _mediator.Send(new RegisterUserCommand(request.Email, request.Password));

            if (response != null)
                return BadRequest();

            return Ok(response);

        }
    }

    public class RequestUserRegistration
    {

        public string Email { get; set; }
        public string Password { get; set; }
    }
}


