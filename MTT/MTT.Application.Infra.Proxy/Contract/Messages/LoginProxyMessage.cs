using System.Text.Json.Serialization;

namespace MTT.Application.Infra.Proxy.Contract.Messages
{
    public class LoginProxyMessage
    {
        [JsonPropertyName("access_token")]
        public string Token { get; set; }

        [JsonPropertyName("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonPropertyName("token_type")]
        public string TokenType { get; set; }

        [JsonPropertyName("scope")]
        public string Scope { get; set; }        
    }
}
