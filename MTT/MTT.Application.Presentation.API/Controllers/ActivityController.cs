using Microsoft.AspNetCore.Mvc;
using MTT.Application.AppService.Contracts.Requests.Activity;
using MTT.Application.AppService.Interfaces;
using System.Net;
using System.Threading.Tasks;

namespace MTT.Application.Presentation.API.Controllers
{
    [Route("api/activity")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityApplicationService _activityApplicationService;
        public ActivityController(IActivityApplicationService activityApplicationService)
        => _activityApplicationService = activityApplicationService;

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Post([FromBody]CreateActivityRequest request)
        {
            var response = await _activityApplicationService.CreateAsync(request);

            if (response.Success)
                return StatusCode((int)HttpStatusCode.Created, response.Id);
            else
                return StatusCode((int)HttpStatusCode.BadRequest, response.Errors);
        }

        [HttpPut]
        [Route("concluded/{Id}")]
        public async Task<IActionResult> Put([FromBody]ConcludedActivityRequest request)
        {
            var response = await _activityApplicationService.ConcludedAsync(request);

            if (response.Success)
                return StatusCode((int)HttpStatusCode.OK, response.Message);
            else
                return StatusCode((int)HttpStatusCode.BadRequest, response.Errors);
        }

        [HttpPut][Route("update/{id}")]
        public async Task<IActionResult> Put([FromBody]UpdateActivityRequest request)
        {
            var response = await _activityApplicationService.UpdateAsync(request);

            if (response.Success)
                return StatusCode((int)HttpStatusCode.OK, response.Message);
            else
                return StatusCode((int)HttpStatusCode.BadRequest, response.Errors);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute]DeleteActivityRequest request)
        {
            var response = await _activityApplicationService.DeleteAsync(request);

            if (response.Success)
                return StatusCode((int)HttpStatusCode.NoContent, response);
            else
                return StatusCode((int)HttpStatusCode.NotFound, response.Errors);
        }

        [HttpGet]
        [Route("/get")]
        public async Task<IActionResult> Get([FromQuery]GetActivityRequest request)
        {
            var response = await _activityApplicationService.GetByIdAsync(request);

            if (response.Success)
                return StatusCode((int)HttpStatusCode.OK, response.ActivityMessage);
            else
                return StatusCode((int)HttpStatusCode.NotFound, response.Errors);
        }


    }
}