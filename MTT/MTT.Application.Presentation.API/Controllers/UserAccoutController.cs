using Microsoft.AspNetCore.Mvc;
using MTT.Application.AppService.Contracts.Requests;
using MTT.Application.AppService.Interfaces;

namespace MTT.Application.Presentation.API.Controllers
{
    [Route("api/useraccount")]
    [ApiController]
    public class UserAccoutController : ControllerBase
    {
        private readonly IUserApplicationService _userApplicationService;
        public UserAccoutController(IUserApplicationService userApplicationService)
        => _userApplicationService = userApplicationService;

        [HttpPost]
        public IActionResult Post([FromBody]CreateUserRequest request)
        {
            var response = _userApplicationService.CreateUser(request);

            return Ok(response);
        }
    }
}