﻿using Microsoft.AspNetCore.Mvc;
using MTT.Application.AppService.Contracts.Messages.Muster;
using MTT.Application.AppService.Contracts.Requests.Muster;
using MTT.Application.AppService.Interfaces;
using System.Net;
using System.Threading.Tasks;

namespace MTT.Application.Presentation.API.Controllers
{
    [Route("api/muster")]
    [ApiController]
    public class MusterController : ControllerBase
    {
        private readonly IMusterApplicationService _musterApplicationService;
        public MusterController(IMusterApplicationService musterApplicationService)
        => _musterApplicationService = musterApplicationService;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateMusterRequest request)
        {
            var response = await _musterApplicationService.CreateAsync(request);

            if (response.Success)
                return StatusCode((int)HttpStatusCode.Created, response.Id);
            else
                return StatusCode((int)HttpStatusCode.BadRequest, response.Errors);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody]UpdateMusterRequest request)
        {
            var response = await _musterApplicationService.UpdateAsync(request);

            if (response.Success)
                return StatusCode((int)HttpStatusCode.Created, response.Muster);
            else
                return StatusCode((int)HttpStatusCode.BadRequest, response.Errors);
        }

        [HttpPatch][Route("/wasconcluded")]
        public async Task<IActionResult> Put([FromBody]MusterConcludedRequest request)
        {
            var response = await _musterApplicationService.WasConcludedAsync(request);

            if (response.Success)
                return StatusCode((int)HttpStatusCode.Created, response.Muster);
            else
                return StatusCode((int)HttpStatusCode.BadRequest, response.Errors);
        }

        [HttpGet][Route("/list")]
        public async Task<IActionResult> Get([FromQuery]ListMusterRequest request)
        {
            var response = await _musterApplicationService.ListMusterAsync(request);

            if (response.Success)
                return StatusCode((int)HttpStatusCode.OK, response.Result);
            else
                return StatusCode((int)HttpStatusCode.NotFound, response.Errors);
        }

        [HttpGet][Route("{id}")]
        public async Task<IActionResult> Get([FromQuery]GetMusterRequest request)
        {
            var response = await _musterApplicationService.GetMusterByIdAsync(request);

            if (response.Success)
                return StatusCode((int)HttpStatusCode.OK, response.Result);
            else
                return StatusCode((int)HttpStatusCode.NotFound, response.Errors);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody]DeleteMusterRequest request)
        {
            var response = await _musterApplicationService.DeletedAsync(request);
            
            if (response.Success)
                return StatusCode((int)HttpStatusCode.NoContent, response);
            else
                return StatusCode((int)HttpStatusCode.NotFound, response.Errors);
        }

    }
}