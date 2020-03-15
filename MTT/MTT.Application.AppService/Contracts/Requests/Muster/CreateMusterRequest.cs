
using System.Text.Json.Serialization;

namespace MTT.Application.AppService.Contracts.Requests.Muster
{
    public class CreateMusterRequest
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("categoryId")]
        public int CategoryId { get; set; }
    }
}
