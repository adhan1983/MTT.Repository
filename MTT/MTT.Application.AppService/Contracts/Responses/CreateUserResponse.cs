using System.Text.Json.Serialization;

namespace MTT.Application.AppService.Contracts.Responses
{
    public class CreateUserResponse : BaseResponse
    {
        public CreateUserResponse(bool success, int id = 0, string error = "")
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
