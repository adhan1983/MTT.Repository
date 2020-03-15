using MTT.Application.AppService.Contracts.Requests.Activity;
using MTT.Application.AppService.Contracts.Responses.Activity;
using System.Threading.Tasks;

namespace MTT.Application.AppService.Interfaces
{
    public interface IActivityApplicationService
    {
        Task<ConcludedActivityResponse> ConcludedAsync(ConcludedActivityRequest request);
        Task<CreateActivityResponse> CreateAsync(CreateActivityRequest request);
        Task<DeleteActivityResponse> DeleteAsync(DeleteActivityRequest request);
        Task<GetActivityResponse> GetByIdAsync(GetActivityRequest request);
        Task<UpdateActivityResponse> UpdateAsync(UpdateActivityRequest request);
    }
}
