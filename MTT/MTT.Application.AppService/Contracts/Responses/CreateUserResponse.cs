using MTT.Application.AppService.Contracts.Messages;
using System.Text.Json.Serialization;

namespace MTT.Application.AppService.Contracts.Responses
{
    public class CreateUserResponse : BaseResponse
    {
        public CreateUserResponse(bool success, GetUseMessage result = null, string error = "")
        {
            Result = result;
            Success = success;
            if (!success)
                SetError(error);
        }
        [JsonPropertyName("id")]
        public GetUseMessage Result { get; private set; }
    }
}
