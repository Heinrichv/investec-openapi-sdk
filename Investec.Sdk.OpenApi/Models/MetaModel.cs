using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Investec.Sdk.OpenApi.Models
{
    public class MetaModel
    {
        [JsonPropertyName("totalPages")]
        public int TotalPages { get; set; }
    }
}
