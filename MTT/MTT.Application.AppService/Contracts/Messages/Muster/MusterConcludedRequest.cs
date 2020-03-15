using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MTT.Application.AppService.Contracts.Messages.Muster
{
    public class MusterConcludedRequest
    {
        [JsonPropertyName("id")] [Required]
        public int Id { get; set; }
        
        [JsonPropertyName("id")] [Required]
        public bool WasConcluded { get; set; }
    }
}
