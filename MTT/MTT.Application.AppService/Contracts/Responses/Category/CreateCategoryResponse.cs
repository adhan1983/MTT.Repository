using System.Text.Json.Serialization;

namespace MTT.Application.AppService.Contracts.Responses.Category
{
    public class CreateCategoryResponse : BaseResponse
    {
        public CreateCategoryResponse(bool success, int id = 0, string error = "")
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
