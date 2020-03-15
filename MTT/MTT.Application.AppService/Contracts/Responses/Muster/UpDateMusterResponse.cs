using MTT.Application.AppService.Contracts.Messages.Muster;
using System.Text.Json.Serialization;

namespace MTT.Application.AppService.Contracts.Responses.Muster
{
    public class UpDateMusterResponse : BaseResponse
    {
        public UpDateMusterResponse(bool success, UpdateMusterMessage muster = null, string error = "")
        {
            Muster = muster;
            Success = success;
            if (!success)
                SetError(error);
        }

        [JsonPropertyName("muster")]
        public UpdateMusterMessage Muster { get; set; }
    }
}
