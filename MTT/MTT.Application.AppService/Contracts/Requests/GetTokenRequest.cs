using System.Text.Json.Serialization;

namespace MTT.Application.AppService.Contracts.Requests
{
    public class GetTokenRequest
    {
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}
