using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MTT.Application.AppService.Contracts.Responses
{
    public abstract class BaseResponse
    {
        [JsonIgnore]
        public bool Success { get; protected set; }
        public IList<string> Errors { get; protected set; }
        public string Message { get; protected set; }

        public void SetError(string error)
        {
            Success = false;
            if (Errors == null)
                Errors = new List<string>();
            Errors.Add(error);
        }
    }
}
