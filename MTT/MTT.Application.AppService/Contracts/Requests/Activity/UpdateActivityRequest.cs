using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MTT.Application.AppService.Contracts.Requests.Activity
{
    public class UpdateActivityRequest
    {
        [JsonPropertyName("id")][Required]
        public int Id { get; set; }

        [JsonPropertyName("name")][Required]
        public string Name { get; set; }

        [JsonPropertyName("musterId")][Required]
        public int MusterId { get; set; }

        [JsonPropertyName("userId")][Required]
        public int UserId { get; set; }
    }
}
