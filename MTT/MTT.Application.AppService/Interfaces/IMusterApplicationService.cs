using MTT.Application.AppService.Contracts.Messages.Muster;
using MTT.Application.AppService.Contracts.Requests.Muster;
using MTT.Application.AppService.Contracts.Responses.Muster;
using System.Threading.Tasks;

namespace MTT.Application.AppService.Interfaces
{
    public interface IMusterApplicationService
    {
        Task<CreateMusterResponse> CreateAsync(CreateMusterRequest request);
        Task<UpDateMusterResponse> UpdateAsync(UpdateMusterRequest request);
        Task<ConcludedMusterResponse> WasConcludedAsync(MusterConcludedRequest request);
        Task<DeleteMusterResponse> DeletedAsync(DeleteMusterRequest request);
        Task<ListMusterResponse> ListMusterAsync(ListMusterRequest request);
        Task<GetMusterResponse> GetMusterByIdAsync(GetMusterRequest request);
    }
}
