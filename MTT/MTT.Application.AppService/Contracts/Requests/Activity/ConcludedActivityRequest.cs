using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace MTT.Application.AppService.Contracts.Requests.Activity
{
    public class ConcludedActivityRequest
    {
        [JsonPropertyName("id")] [Required]
        public int Id { get; set; }

        [JsonPropertyName("wasConcluded")][Required]
        public bool WasConcluded { get; set; }
    }
}
