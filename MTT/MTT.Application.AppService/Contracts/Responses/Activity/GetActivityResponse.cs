using System.Text.Json.Serialization;
using MTT.Application.AppService.Contracts.Messages.Activity;

namespace MTT.Application.AppService.Contracts.Responses.Activity
{
    public class GetActivityResponse : BaseResponse
    {
        public GetActivityResponse(bool success, GetActivityMessage activityMessage = null, string error = "") 
        {
            ActivityMessage = activityMessage;
            Success = success;
            if (!success)
                SetError(error);
        }

        [JsonPropertyName("activity")]
        public GetActivityMessage ActivityMessage { get; private set; }
    }
}
