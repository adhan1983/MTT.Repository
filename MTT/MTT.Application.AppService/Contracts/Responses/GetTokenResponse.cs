using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MTT.Application.AppService.Contracts.Responses
{
    public class GetTokenResponse : BaseResponse
    {
        public GetTokenResponse(bool success, string token = "", string error = "") 
        {
            Token = token;
            Success = success;
            if (!success)
                SetError(error);
        }

        [JsonPropertyName("token")]
        public string Token { get; set; }
    }
}
