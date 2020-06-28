using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Investec.Sdk.OpenApi.Models.Response
{
    public class InvestecBalanceResponse
    {
        [JsonPropertyName("data")]
        public BalanceModel Data { get; set; }

        [JsonPropertyName("links")]
        public LinkModel Links { get; set; }

        [JsonPropertyName("meta")]
        public MetaModel Meta { get; set; }
    }
}
