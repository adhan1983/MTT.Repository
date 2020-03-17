using MTT.Application.AppService.Contracts.Messages.Category;
using System.Text.Json.Serialization;

namespace MTT.Application.AppService.Contracts.Responses.Category
{
    public class UpdateCategoryResponse : BaseResponse
    {
        public UpdateCategoryResponse(bool success, UpdateCategoryMessage category = null, string error = "")
        {
            Category = category;
            Success = success;
            if (!success)
                SetError(error);
        }

        [JsonPropertyName("category")]
        public UpdateCategoryMessage Category { get; set; }
    }
}
