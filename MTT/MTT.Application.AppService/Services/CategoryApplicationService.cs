using MTT.Application.AppService.Contracts.Messages.Category;
using MTT.Application.AppService.Contracts.Requests.Category;
using MTT.Application.AppService.Contracts.Responses.Category;
using MTT.Application.AppService.Interfaces;
using MTT.Application.Domain.Domain;
using MTT.Application.Domain.Interfaces.Services;
using System.Threading.Tasks;

namespace MTT.Application.AppService.Services
{
    public class CategoryApplicationService : ICategoryApplicationService
    {
        public readonly ICategoryDomainService _categoryDomainService;
        public CategoryApplicationService(ICategoryDomainService categoryDomainService)
        => _categoryDomainService = categoryDomainService;
        public async Task<CreateCategoryResponse> CreateAsync(CreateCategoryRequest request)
        {
            var model = new Category { Name = request.Name };

            var result = await _categoryDomainService.InsertAsync(model);
            if (result)
                return new CreateCategoryResponse(true, model.Id);
            else
                return new CreateCategoryResponse(true, error: "Fail to Create Category");
        }
        public async Task<UpdateCategoryResponse> UpdateAsync(UpdateCategoryRequest request)
        {
            var model = await _categoryDomainService.GetByIdAsync(request.Id);
            
            model.Name = request.Name;

            var result = await _categoryDomainService.UpdateAsync(model);
            
            if (result)
                return new UpdateCategoryResponse(true, new UpdateCategoryMessage { Id = model.Id, Name = model.Name });
            else
                return new UpdateCategoryResponse(true, error: "Fail to Create Category");
        }
    }
}
