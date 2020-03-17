using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MTT.Application.AppService.Contracts.Requests.Activity
{
    public class DeleteActivityRequest
    {
        [JsonPropertyName("id")][Required]
        public int Id { get; set; }
    }
}
