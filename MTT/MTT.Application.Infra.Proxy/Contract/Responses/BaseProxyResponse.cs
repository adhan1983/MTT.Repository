using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MTT.Application.Infra.Proxy.Contract.Responses
{
    public class BaseProxyResponse
    {
        [JsonIgnore]
        public bool Success { get; protected set; }
        public Dictionary<string, string> DictionaryError { get; protected set; }
        public void SetError(Dictionary<string, string> dictionaryError)
        {
            Success = false;

            if (DictionaryError == null)
            {
                DictionaryError = new Dictionary<string, string>();

                foreach (var error in dictionaryError)
                    DictionaryError.Add(error.Key, error.Value);
            }
        }
    }
}
