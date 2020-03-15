﻿using System.Net;
using Microsoft.AspNetCore.Mvc;
using MTT.Application.AppService.Interfaces;
using MTT.Application.AppService.Contracts.Requests;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Post([FromBody]CreateUserRequest request)
        {
            var response = await _userApplicationService.CreateUserAsync(request);
            
            if (response.Success)
                return StatusCode((int)HttpStatusCode.Created, response.Id);
            else
                return StatusCode((int)HttpStatusCode.BadRequest, response.Errors);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]GetUserRequest request) 
        {
            var response = await _userApplicationService.GetUserAsync(request);

            if (response.Success)
                return StatusCode((int)HttpStatusCode.OK, response.User);
            else
                return StatusCode((int)HttpStatusCode.NotFound, response.Errors);
        }

        [HttpGet]
        [Route("/list")]
        public async Task<IActionResult> GetAllAsync([FromQuery]ListUserRequest request)
        {
            var response = await _userApplicationService.ListUserAsync(request);

            if (response.Success)
                return StatusCode((int)HttpStatusCode.OK, response.Users);
            else
                return StatusCode((int)HttpStatusCode.NotFound, response.Errors);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody]DeleteUserRequest request) 
        {
            var response = await _userApplicationService.DeleteUserAsync(request);

            if (response.Success)
                return StatusCode((int)HttpStatusCode.NoContent, response);
            else
                return StatusCode((int)HttpStatusCode.NotFound, response.Errors);
        }
    }
}