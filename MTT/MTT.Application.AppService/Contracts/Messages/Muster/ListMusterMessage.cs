using MTT.Application.AppService.Contracts.Messages.Category;
using System.Text.Json.Serialization;

namespace MTT.Application.AppService.Contracts.Messages.Muster
{
    public class ListMusterMessage
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("wasConcluded")]
        public bool WasConcluded { get; set; }       

        [JsonPropertyName("category")]
        public GetCategoryMessage Category { get; set; }
    }
}
