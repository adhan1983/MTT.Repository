using System.Text.Json.Serialization;

namespace MTT.Application.AppService.Contracts.Requests
{
    public class CreateUserRequest
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}
