using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Investec.Sdk.OpenApi.Models
{
    public class BalanceModel
    {
        [JsonPropertyName("accountId")]
        public string AccountId { get; set; }

        [JsonPropertyName("currentBalance")]
        public double? CurrentBalance { get; set; }

        [JsonPropertyName("availableBalance")]
        public double? AvailableBalance { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }
    }
}
