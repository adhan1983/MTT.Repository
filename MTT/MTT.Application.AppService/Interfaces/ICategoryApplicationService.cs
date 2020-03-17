using MTT.Application.AppService.Contracts.Requests.Category;
using MTT.Application.AppService.Contracts.Responses.Category;
using System.Threading.Tasks;

namespace MTT.Application.AppService.Interfaces
{
    public interface ICategoryApplicationService
    {
        Task<CreateCategoryResponse> CreateAsync(CreateCategoryRequest request);
        Task<UpdateCategoryResponse> UpdateAsync(UpdateCategoryRequest request);
        Task<ListCategoryResponse> ListCategoryAsync();
    }
}
