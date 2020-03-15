using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MTT.Application.AppService.Contracts.Messages.Muster
{
    public class UpdateMusterMessage
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("name")]
        public bool WasConcluded { get; set; }
    }
}
