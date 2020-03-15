using System.Text.Json.Serialization;

namespace MTT.Application.AppService.Contracts.Responses.Activity
{
    public class CreateActivityResponse : BaseResponse
    {
        public CreateActivityResponse(bool success, int id = 0, string error = "")
        {
            Id = id;
            Success = success;
            if (!success)
                SetError(error);
        }
        [JsonPropertyName("id")]
        public int Id { get; private set; }
    }
}
