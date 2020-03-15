using System.Text.Json.Serialization;

namespace MTT.Application.AppService.Contracts.Messages
{
    public class GetUseMessage
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
    }
}
