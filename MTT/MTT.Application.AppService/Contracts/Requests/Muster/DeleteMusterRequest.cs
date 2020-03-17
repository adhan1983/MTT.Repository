using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MTT.Application.AppService.Contracts.Requests.Muster
{
    public class DeleteMusterRequest
    {
        [JsonPropertyName("id")][Required]
        public int Id { get; set; }
    }
}
