using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MTT.Application.AppService.Contracts.Requests.Muster
{
    public class GetMusterRequest
    {
        [JsonPropertyName("id"), Required]
        public int Id { get; set; }
    }
}
