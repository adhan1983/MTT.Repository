using System.Text.Json.Serialization;

namespace MTT.Application.AppService.Contracts.Messages.Category
{
    public class GetCategoryMessage
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
