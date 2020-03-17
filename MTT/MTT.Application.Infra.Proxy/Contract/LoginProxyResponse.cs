using MTT.Application.Infra.Proxy.Contract.Messages;
using MTT.Application.Infra.Proxy.Contract.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MTT.Application.Infra.Proxy.Contract
{
    public class LoginProxyResponse : BaseProxyResponse
    {
        public LoginProxyResponse(bool success) => Success = success;
        public LoginProxyResponse(bool success, LoginProxyMessage result)
        {
            Success = success;
            Result = result;
        }
        public LoginProxyResponse(bool success, Dictionary<string, string> errors)
        {
            Success = success;

            if (!success)
                SetError(errors);
        }
        [JsonPropertyName("result")]
        public LoginProxyMessage Result { get; set; }
    }
}
