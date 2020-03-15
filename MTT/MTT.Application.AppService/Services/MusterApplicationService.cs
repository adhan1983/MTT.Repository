using MTT.Application.AppService.Contracts.Messages.Category;
using MTT.Application.AppService.Contracts.Messages.Muster;
using MTT.Application.AppService.Contracts.Requests.Muster;
using MTT.Application.AppService.Contracts.Responses.Muster;
using MTT.Application.AppService.Interfaces;
using MTT.Application.Domain.Domain;
using MTT.Application.Domain.Interfaces.Services;
using MTT.Application.Domain.Utilities;
using System.Linq;
using System.Threading.Tasks;

namespace MTT.Application.AppService.Services
{
    public class MusterApplicationService : IMusterApplicationService
    {
        public readonly IMusterDomainService _musterDomainService;
        public MusterApplicationService(IMusterDomainService musterDomainService)
        => _musterDomainService = musterDomainService;
        public async Task<CreateMusterResponse> CreateAsync(CreateMusterRequest request)
        {
            var model = new Muster();

            model.Add(request.Name, request.CategoryId);

            var result = await _musterDomainService.InsertAsync(model);
            
            if (result)
                return new CreateMusterResponse(true, model.Id);
            else
                return new CreateMusterResponse(true, error: "Fail to Create Muster");
        }
        public async Task<UpDateMusterResponse> UpdateAsync(UpdateMusterRequest request)
        {
            var model = await _musterDomainService.GetByIdAsync(request.Id);

            if (model != null && model.Id > 0)
            {
                model.Update(request.Name, request.CategoryId);

                var result = await _musterDomainService.UpdateAsync(model);               

                if (result)
                    return new UpDateMusterResponse(true, message: "Muster was updated successfully!");
                else
                    return new UpDateMusterResponse(false, error: "Fail to update Muster");
            }
            else
                return new UpDateMusterResponse(false, error: "Fail to update Muster");
        }
        public async Task<ConcludedMusterResponse> WasConcludedAsync(MusterConcludedRequest request)
        {
            var model = await _musterDomainService.GetByIdAsync(request.Id);

            if (model != null && !model.WasConcluded)
            {
                model.Concluded(request.WasConcluded);

                var result = await _musterDomainService.UpdateAsync(model);

                if (result)
                    return new ConcludedMusterResponse(true, message: "Muster was concluded successfully!");
                else
                    return new ConcludedMusterResponse(false, error: "Fail to conclude Muster");
            }
            else
                return new ConcludedMusterResponse(false, error: "Fail to conclude Muster");
        }
        public async Task<DeleteMusterResponse> DeletedAsync(DeleteMusterRequest request)
        {
            var model = await _musterDomainService.GetByIdAsync(request.Id);

            if (model != null && model.Id > 0 && await _musterDomainService.DeleteAsync(model))
                return new DeleteMusterResponse(true);
            else
                return new DeleteMusterResponse(false, error: "Fail to delete user!");
        }
        public async Task<ListMusterResponse> ListMusterAsync(ListMusterRequest request)
        {
            var predicate = PredicateBuilder.True<Muster>();

            predicate = predicate.And(p => p.Name.Contains(request.Name));

            predicate = predicate.And(p => p.CategoryId == request.CategoryId);

            var response = await _musterDomainService.GetAllByFilter(predicate);

            if (response != null && response.Count() > 0)
            {
                var lst = response.
                    Select(mu =>
                    new ListMusterMessage
                    {
                        Id = mu.Id,
                        Name = mu.Name,
                        WasConcluded = mu.WasConcluded,
                        Category = new GetCategoryMessage() { Id = mu.CategoryId, Name = mu.Category.Name }
                    }).
                    ToList();

                return new ListMusterResponse(true, lst);
            }
            else
                return new ListMusterResponse(false);
        }
        public async Task<GetMusterResponse> GetMusterByIdAsync(GetMusterRequest request)
        {
            var response = await _musterDomainService.GetMusterByIdWithCategory(request.Id);

            if (response != null && response.Id > 0)
            {
                var musterMessage = new GetMusterMessage
                {
                    Id = response.Id,
                    Name = response.Name,
                    WasConcluded = response.WasConcluded,
                    Category = new GetCategoryMessage() { Id = response.CategoryId, Name = response.Category.Name }
                };
                return new GetMusterResponse(true, musterMessage);
            }
            else
                return new GetMusterResponse(false);
        }
    }
}
