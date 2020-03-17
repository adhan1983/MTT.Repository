using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MTT.Application.AppService.Contracts.Requests.Muster
{
    public class MusterConcludedRequest
    {
        [JsonPropertyName("id")] [Required]
        public int Id { get; set; }
        
        [JsonPropertyName("wasConcluded")] [Required]
        public bool WasConcluded { get; set; }
    }
}
