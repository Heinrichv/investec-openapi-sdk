using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Investec.Sdk.OpenApi.Models
{
    public class InvestecOpenApiConfiguration
    {
        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("clientId")]
        public string ClientId { get; set; }

        [JsonPropertyName("secret")]
        public string Secret { get; set; }
    }
}
