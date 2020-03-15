using MTT.Application.AppService.Contracts.Messages;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MTT.Application.AppService.Contracts.Responses
{
    public class ListUserResponse : BaseResponse
    {
        public ListUserResponse(bool success, List<ListUserMessage> users = null, string error = "")
        {
            Users = users;
            Success = success;
            if (!success)
                SetError(error);
        }
        [JsonPropertyName("users")]
        public List<ListUserMessage> Users { get; set; }
    }
}
