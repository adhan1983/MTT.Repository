using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MTT.Application.AppService.Contracts.Requests.Muster
{
    public class UpdateMusterRequest
    {
        [JsonPropertyName("id")][Required]
        public int Id { get; set; }

        [JsonPropertyName("name")][Required]
        public string Name { get; set; }

        [JsonPropertyName("categoryId")][Required]
        public int CategoryId { get; set; }
    }
}
