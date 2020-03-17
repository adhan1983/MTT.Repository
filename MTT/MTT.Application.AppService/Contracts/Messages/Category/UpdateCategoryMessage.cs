using System.Text.Json.Serialization;

namespace MTT.Application.AppService.Contracts.Messages.Category
{
    public class UpdateCategoryMessage
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
