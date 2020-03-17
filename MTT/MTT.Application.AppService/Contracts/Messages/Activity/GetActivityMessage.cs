using System.Text.Json.Serialization;
using MTT.Application.AppService.Contracts.Messages.Muster;

namespace MTT.Application.AppService.Contracts.Messages.Activity
{
    public class GetActivityMessage
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("wasConcluded")]
        public bool WasConcluded { get; set; }

        [JsonPropertyName("muster")]
        public GetMusterMessage Muster { get; set; }

        [JsonPropertyName("user")]
        public GetUseMessage User { get; set; }
    }
}
