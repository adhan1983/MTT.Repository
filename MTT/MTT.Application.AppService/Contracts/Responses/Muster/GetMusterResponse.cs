using MTT.Application.AppService.Contracts.Messages.Muster;
using System.Text.Json.Serialization;

namespace MTT.Application.AppService.Contracts.Responses.Muster
{
    public class GetMusterResponse : BaseResponse
    {
        public GetMusterResponse(bool success, GetMusterMessage result = null, string error = "") 
        {
            Result = result;
            Success = success;
            if (!success)
                SetError(error);
        }
        [JsonPropertyName("result")]
        public GetMusterMessage Result { get; set; }
    }
}
