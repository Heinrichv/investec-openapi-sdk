using System;
using System.Text.Json.Serialization;

namespace Investec.Sdk.OpenApi.Models
{
    public class TransactionModel
    {
        [JsonPropertyName("accountId")]
        public string AccountId { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("cardNumber")]
        public string CardNumber { get; set; }

        [JsonPropertyName("postingDate")]
        public DateTime PostingDate { get; set; }

        [JsonPropertyName("valueDate")]
        public DateTime ValueDate { get; set; }

        [JsonPropertyName("actionDate")]
        public DateTime ActionDate { get; set; }

        [JsonPropertyName("amount")]
        public double Amount { get; set; }
    }
}