using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Investec.Sdk.OpenApi.Models
{
    public class DataModel
    {
        [JsonPropertyName("accounts")]
        public List<AccountModel> Accounts { get; set; }

        [JsonPropertyName("transactions")]
        public List<TransactionModel> Transactions { get; set; }
    }
}
