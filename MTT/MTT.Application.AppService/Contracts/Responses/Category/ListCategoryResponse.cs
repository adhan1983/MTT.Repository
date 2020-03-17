using MTT.Application.AppService.Contracts.Messages.Category;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MTT.Application.AppService.Contracts.Responses.Category
{
    public class ListCategoryResponse : BaseResponse
    {
        public ListCategoryResponse(bool success, List<ListCategoryMessage> categories = null, string error = "")
        {
            Categories = categories;
            Success = success;
            if (!success)
                SetError(error);
        }

        [JsonPropertyName("categories")]
        public List<ListCategoryMessage> Categories { get; set; }
    }
}
