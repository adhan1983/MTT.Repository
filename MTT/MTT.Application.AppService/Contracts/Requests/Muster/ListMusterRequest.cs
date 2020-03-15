using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MTT.Application.AppService.Contracts.Requests.Muster
{
    public class ListMusterRequest
    {
        [JsonPropertyName("name"), Required]
        public string Name { get; set; }

        [JsonPropertyName("category"), Required]
        public int CategoryId { get; set; }
    }
}
