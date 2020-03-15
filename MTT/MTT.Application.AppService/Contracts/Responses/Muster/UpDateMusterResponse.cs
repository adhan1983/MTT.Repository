using MTT.Application.AppService.Contracts.Messages.Muster;
using System.Text.Json.Serialization;

namespace MTT.Application.AppService.Contracts.Responses.Muster
{
    public class UpDateMusterResponse : BaseResponse
    {
        public UpDateMusterResponse(bool success, string message = "", string error = "")
        {
            Message = message;
            Success = success;
            if (!success)
                SetError(error);
        }
    }
}
