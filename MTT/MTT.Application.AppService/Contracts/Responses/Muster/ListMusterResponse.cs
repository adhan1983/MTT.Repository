using System.Collections.Generic;
using System.Text.Json.Serialization;
using MTT.Application.AppService.Contracts.Messages.Muster;

namespace MTT.Application.AppService.Contracts.Responses.Muster
{
    public class ListMusterResponse : BaseResponse
    {
        public ListMusterResponse(bool success, List<ListMusterMessage> result = null, string error = "")  
        {
            Result = result;
            Success = success;
            if (!success)
                SetError(error);
        }

        [JsonPropertyName("result")]
        public List<ListMusterMessage> Result { get; set; }
    }    
}
