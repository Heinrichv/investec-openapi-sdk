using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Investec.Sdk.OpenApi.Models
{
    public class LinkModel
    {
        [JsonPropertyName("self")]
        public string Self { get; set; }
    }
}
