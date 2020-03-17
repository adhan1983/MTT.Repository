using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MTT.Application.AppService.Interfaces;
using MTT.Application.AppService.Contracts.Requests.Category;
using Microsoft.AspNetCore.Authorization;

namespace MTT.Application.Presentation.API.Controllers
{
    [Route("api/category")]
    [ApiController]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryApplicationService _categoryApplicationService;
        public CategoryController(ICategoryApplicationService categoryApplicationService)
        => _categoryApplicationService = categoryApplicationService;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateCategoryRequest request)
        {
            var response = await _categoryApplicationService.CreateAsync(request);

            if (response.Success)
                return StatusCode((int)HttpStatusCode.Created, response.Id);
            else
                return StatusCode((int)HttpStatusCode.BadRequest, response.Errors);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody]UpdateCategoryRequest request)
        {
            var response = await _categoryApplicationService.UpdateAsync(request);

            if (response.Success)
                return StatusCode((int)HttpStatusCode.OK, response.Category);
            else
                return StatusCode((int)HttpStatusCode.BadRequest, response.Errors);
        }

        [HttpGet][Route("list")]
        public async Task<IActionResult> Get()
        {
            var response = await _categoryApplicationService.ListCategoryAsync();

            if (response.Success)
                return StatusCode((int)HttpStatusCode.OK, response.Categories);
            else
                return StatusCode((int)HttpStatusCode.NotFound, response.Errors);
        }
    }
}