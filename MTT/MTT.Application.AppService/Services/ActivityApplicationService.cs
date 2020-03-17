using MTT.Application.AppService.Contracts.Messages;
using MTT.Application.AppService.Contracts.Messages.Activity;
using MTT.Application.AppService.Contracts.Messages.Category;
using MTT.Application.AppService.Contracts.Messages.Muster;
using MTT.Application.AppService.Contracts.Requests.Activity;
using MTT.Application.AppService.Contracts.Responses.Activity;
using MTT.Application.AppService.Interfaces;
using MTT.Application.Domain.Domain;
using MTT.Application.Domain.Interfaces.Services;
using System.Threading.Tasks;

namespace MTT.Application.AppService.Services
{
    public class ActivityApplicationService : IActivityApplicationService
    {
        private readonly IActivityDomainService _activityDomainService;
        public ActivityApplicationService(IActivityDomainService activityDomainService)
            => _activityDomainService = activityDomainService;
        public async Task<ConcludedActivityResponse> ConcludedAsync(ConcludedActivityRequest request)
        {
            var model = await _activityDomainService.GetByIdAsync(request.Id);

            if (model != null && model.Id > 0)
            {
                model.Concluded(request.WasConcluded);

                var result = await _activityDomainService.UpdateAsync(model);
                
                if (result)
                    return new ConcludedActivityResponse(true, message: "The activity was completed successfully!");
                else
                    return new ConcludedActivityResponse(false, error: "Fail to conclude this Activity");
            }
            else
                return new ConcludedActivityResponse(false, error: "Fail to conclude this Activity");            
        }
        public async Task<CreateActivityResponse> CreateAsync(CreateActivityRequest request)
        {
            var model = new Activity();
            
            model.Add(request.Name, request.MusterId, request.UserId);

            var result = await _activityDomainService.InsertAsync(model);

            if (result)
                return new CreateActivityResponse(true, model.Id);
            else
                return new CreateActivityResponse(false, error: "Fail to create this Activity");
        }
        public async Task<DeleteActivityResponse> DeleteAsync(DeleteActivityRequest request)
        {
            var model = await _activityDomainService.GetByIdAsync(request.Id);

            if (model != null && model.Id > 0)
            {
                var result = await _activityDomainService.DeleteAsync(model);

                if (result)
                    return new DeleteActivityResponse(true, message: "The Activity was deleted!");
                else
                    return new DeleteActivityResponse(false, error: "Fail to delete The Activity");
            }
            else
                return new DeleteActivityResponse(false, error: "Fail to delete The Activity");            
        }
        public async Task<GetActivityResponse> GetByIdAsync(GetActivityRequest request)
        {
            var model = await _activityDomainService.GetActivityById(request.Id);

            if (model != null && model.Id > 0)
            {
                var message = new GetActivityMessage();
                message.Id = model.Id;
                message.Name = model.Name;
                message.WasConcluded = model.WasConcluded;
                if(model.User != null && model.User.Id > 0)
                    message.User = 
                        new GetUseMessage() { 
                            Id = model.User.Id, 
                            Name = model.User.Name, 
                            Email = model.User.Email 
                        };

                if (model.Muster != null && model.Muster.Id > 0) 
                {
                    message.Muster = new GetMusterMessage();
                    message.Muster.Id = model.Muster.Id;
                    message.Muster.Name = model.Muster.Name;
                    if (model.Muster.Category != null && model.Muster.Category.Id > 0) 
                    {
                        message.Muster.Category = new GetCategoryMessage();
                        message.Muster.Category.Id = model.Muster.Category.Id;
                        message.Muster.Category.Name = model.Muster.Category.Name;
                    }
                }
                return new GetActivityResponse(true, message);
            }
            else
                return new GetActivityResponse(false, error: "Fail to get this Activity");            
        }
        public async Task<UpdateActivityResponse> UpdateAsync(UpdateActivityRequest request)
        {
            var model = await _activityDomainService.GetByIdAsync(request.Id);

            if (model != null && model.Id > 0)
            {
                var result = await _activityDomainService.UpdateAsync(model);

                if (result)
                    return new UpdateActivityResponse(true, message: "The Activity was updated!");
                else
                    return new UpdateActivityResponse(false, error: "Fail to update The Activity");
            }
            else
                return new UpdateActivityResponse(false, error: "Fail to update The Activity");
        }
    }
}
