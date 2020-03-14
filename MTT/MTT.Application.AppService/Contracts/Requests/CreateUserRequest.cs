using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MTT.Application.AppService.Contracts.Requests
{
    public class CreateUserRequest
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}
