using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Investec.Sdk.OpenApi.Models.Response
{
    public class InvestecOpenApiErrorResponse
    {
        public InvestecOpenApiErrorResponse()
        {

        }

        public InvestecOpenApiErrorResponse(string message, string errorJson)
        {
            this.ErrorMessage = message;
            this.Error = JsonSerializer.Deserialize<object>(errorJson);
        }

        public InvestecOpenApiErrorResponse(string message, object error)
        {
            this.ErrorMessage = message;
            this.Error = error;
        }

        public InvestecOpenApiErrorResponse(string message)
        {
            this.ErrorMessage = message;   
        }

        [JsonPropertyName("errorMessage")]
        public string ErrorMessage { get; set; }

        [JsonPropertyName("error")]
        public object Error { get; set; }
    }
}
