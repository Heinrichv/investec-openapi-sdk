using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Investec.Sdk.OpenApi.Models
{
    public class AccountModel
    {
        [JsonPropertyName("accountId")]
        public string AccountId { get; set; }

        [JsonPropertyName("accountNumber")]
        public string AccountNumber { get; set; }

        [JsonPropertyName("accountName")]
        public string AccountName { get; set; }

        [JsonPropertyName("referenceName")]
        public string ReferenceName { get; set; }

        [JsonPropertyName("productName")]
        public string ProductName { get; set; }
    }
}
