using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MTT.Application.AppService.Contracts.Responses.Muster
{
    public class CreateMusterResponse : BaseResponse
    {       
        public CreateMusterResponse(bool success, int id = 0, string error = "")
        {
            Id = id;
            Success = success;
            if (!success)
                SetError(error);
        }
        [JsonPropertyName("id")]
        public int Id { get; private set; }
    }
}
