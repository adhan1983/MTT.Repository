using MTT.Application.AppService.Contracts.Messages;
using System.Text.Json.Serialization;

namespace MTT.Application.AppService.Contracts.Responses
{
    public class GetUserResponse : BaseResponse
    {
        public GetUserResponse(bool success, GetUseMessage user = null, string error = "")
        {
            User = user;
            Success = success;
            if (!success)
                SetError(error);
        }
        [JsonPropertyName("user")]
        public GetUseMessage User { get; set; }
    }
}
