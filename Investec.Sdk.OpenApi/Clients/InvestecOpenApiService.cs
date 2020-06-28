using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Investec.Sdk.OpenApi.Models;
using Investec.Sdk.OpenApi.Models.Response;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace Investec.Sdk.OpenApi.Clients
{
    public class InvestecOpenApiService : IInvestecOpenApiService
    {
        private readonly InvestecOpenApiHttpClient _httpClient;
        private readonly InvestecOpenApiConfiguration _openApiConfiguration;
        private readonly ILogger<InvestecOpenApiService> _logger;
        private readonly IMemoryCache _cache;

        public InvestecOpenApiService(IMemoryCache cache, InvestecOpenApiHttpClient httpClient, InvestecOpenApiConfiguration openApiConfiguration, ILogger<InvestecOpenApiService> logger)
        {
            this._httpClient = httpClient;
            this._openApiConfiguration = openApiConfiguration;
            this._logger = logger;
            this._cache = cache;
        }

        public async Task<object> RequestAuthTokenAsync() 
        {
            var paramaters = new Dictionary<string, string>() 
            {
                { "grant_type", "client_credentials" },
                { "scope", "accounts" }
            };

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "/identity/v2/oauth2/token/");

            byte[] bytes = Encoding.UTF8.GetBytes($"{this._openApiConfiguration.ClientId}:{this._openApiConfiguration.Secret}");

            request.Headers.Add(HttpRequestHeader.Authorization.ToString(), $"Basic {Convert.ToBase64String(bytes)}");
            request.Headers.Add(HttpRequestHeader.Accept.ToString(), "application/json");
            request.Content = new FormUrlEncodedContent(paramaters);

            HttpResponseMessage response = await this._httpClient.SendAsync(request);

            InvestecOpenApiErrorResponse errorResponse;

            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    return (object)JsonSerializer.Deserialize<AccessTokenResponse>(await response.Content.ReadAsStringAsync());
                case HttpStatusCode.BadRequest:
                    errorResponse =  new InvestecOpenApiErrorResponse(nameof(ErrorEnum.OperationCancelled), await response.Content.ReadAsStringAsync());
                    this._logger.LogError("The requested operation will not be carried out {0}", JsonSerializer.Serialize(errorResponse, options: new JsonSerializerOptions 
                    {
                        WriteIndented = true
                    }));
                    return (object)errorResponse;
                case HttpStatusCode.Unauthorized:
                    errorResponse = new InvestecOpenApiErrorResponse(nameof(ErrorEnum.OperationRefused), await response.Content.ReadAsStringAsync());
                    this._logger.LogError("The requested operation will not be carried out {0}", JsonSerializer.Serialize(errorResponse, options: new JsonSerializerOptions
                    {
                        WriteIndented = true
                    }));
                    return (object)errorResponse;
                case HttpStatusCode.InternalServerError:
                    errorResponse = new InvestecOpenApiErrorResponse(nameof(ErrorEnum.OperationFailed), await response.Content.ReadAsStringAsync());
                    this._logger.LogError("The requested operation will not be carried out {0}", JsonSerializer.Serialize(errorResponse, options: new JsonSerializerOptions
                    {
                        WriteIndented = true
                    }));
                    return (object)errorResponse;
                default:
                    errorResponse = new InvestecOpenApiErrorResponse(nameof(ErrorEnum.UnknownErrorOccurred), await response.Content.ReadAsStringAsync());
                    this._logger.LogError("The requested operation will not be carried out {0}", JsonSerializer.Serialize(errorResponse, options: new JsonSerializerOptions
                    {
                        WriteIndented = true
                    }));
                    return (object)errorResponse;
            }
        }


        public async Task<object> GetAccountsAsync()
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "/za/pb/v1/accounts/");

            request.Headers.Add(HttpRequestHeader.Authorization.ToString(), await GetAuthorizationTokenAsync());
            request.Headers.Add(HttpRequestHeader.Accept.ToString(), "application/json");

            HttpResponseMessage response = await this._httpClient.SendAsync(request);

            InvestecOpenApiErrorResponse errorResponse;

            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    return (object)JsonSerializer.Deserialize<InvestecResponse>(await response.Content.ReadAsStringAsync());
                case HttpStatusCode.BadRequest:
                    errorResponse = new InvestecOpenApiErrorResponse(nameof(ErrorEnum.OperationCancelled), await response.Content.ReadAsStringAsync());
                    this._logger.LogError("The requested operation will not be carried out {0}", JsonSerializer.Serialize(errorResponse, options: new JsonSerializerOptions
                    {
                        WriteIndented = true
                    }));
                    return (object)errorResponse;
                case HttpStatusCode.Unauthorized:
                    errorResponse = new InvestecOpenApiErrorResponse(nameof(ErrorEnum.OperationRefused), await response.Content.ReadAsStringAsync());
                    this._logger.LogError("The requested operation will not be carried out {0}", JsonSerializer.Serialize(errorResponse, options: new JsonSerializerOptions
                    {
                        WriteIndented = true
                    }));
                    return (object)errorResponse;
                case HttpStatusCode.InternalServerError:
                    errorResponse = new InvestecOpenApiErrorResponse(nameof(ErrorEnum.OperationFailed), await response.Content.ReadAsStringAsync());
                    this._logger.LogError("The requested operation will not be carried out {0}", JsonSerializer.Serialize(errorResponse, options: new JsonSerializerOptions
                    {
                        WriteIndented = true
                    }));
                    return (object)errorResponse;
                default:
                    errorResponse = new InvestecOpenApiErrorResponse(nameof(ErrorEnum.UnknownErrorOccurred), await response.Content.ReadAsStringAsync());
                    this._logger.LogError("The requested operation will not be carried out {0}", JsonSerializer.Serialize(errorResponse, options: new JsonSerializerOptions
                    {
                        WriteIndented = true
                    }));
                    return (object)errorResponse;
            }
        }

        public async Task<object> GetAccountTransactionsAsync(string accountId)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, $"/za/pb/v1/accounts/{accountId}/transactions/");

            request.Headers.Add(HttpRequestHeader.Authorization.ToString(), await GetAuthorizationTokenAsync());
            request.Headers.Add(HttpRequestHeader.Accept.ToString(), "application/json");

            HttpResponseMessage response = await this._httpClient.SendAsync(request);

            InvestecOpenApiErrorResponse errorResponse;

            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    return (object)JsonSerializer.Deserialize<InvestecResponse>(await response.Content.ReadAsStringAsync());
                case HttpStatusCode.BadRequest:
                    errorResponse = new InvestecOpenApiErrorResponse(nameof(ErrorEnum.OperationCancelled), await response.Content.ReadAsStringAsync());
                    this._logger.LogError("The requested operation will not be carried out {0}", JsonSerializer.Serialize(errorResponse, options: new JsonSerializerOptions
                    {
                        WriteIndented = true
                    }));
                    return (object)errorResponse;
                case HttpStatusCode.Unauthorized:
                    errorResponse = new InvestecOpenApiErrorResponse(nameof(ErrorEnum.OperationRefused), await response.Content.ReadAsStringAsync());
                    this._logger.LogError("The requested operation will not be carried out {0}", JsonSerializer.Serialize(errorResponse, options: new JsonSerializerOptions
                    {
                        WriteIndented = true
                    }));
                    return (object)errorResponse;
                case HttpStatusCode.InternalServerError:
                    errorResponse = new InvestecOpenApiErrorResponse(nameof(ErrorEnum.OperationFailed), await response.Content.ReadAsStringAsync());
                    this._logger.LogError("The requested operation will not be carried out {0}", JsonSerializer.Serialize(errorResponse, options: new JsonSerializerOptions
                    {
                        WriteIndented = true
                    }));
                    return (object)errorResponse;
                default:
                    errorResponse = new InvestecOpenApiErrorResponse(nameof(ErrorEnum.UnknownErrorOccurred), await response.Content.ReadAsStringAsync());
                    this._logger.LogError("The requested operation will not be carried out {0}", JsonSerializer.Serialize(errorResponse, options: new JsonSerializerOptions
                    {
                        WriteIndented = true
                    }));
                    return (object)errorResponse;
            }
        }

        public async Task<object> GetAccountBalanceAsync(string accountId)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, $"/za/pb/v1/accounts/{accountId}/balance");

            request.Headers.Add(HttpRequestHeader.Authorization.ToString(), await GetAuthorizationTokenAsync());
            request.Headers.Add(HttpRequestHeader.Accept.ToString(), "application/json");

            HttpResponseMessage response = await this._httpClient.SendAsync(request);

            InvestecOpenApiErrorResponse errorResponse;

            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    return (object)JsonSerializer.Deserialize<InvestecBalanceResponse>(await response.Content.ReadAsStringAsync());
                case HttpStatusCode.BadRequest:
                    errorResponse = new InvestecOpenApiErrorResponse(nameof(ErrorEnum.OperationCancelled), await response.Content.ReadAsStringAsync());
                    this._logger.LogError("The requested operation will not be carried out {0}", JsonSerializer.Serialize(errorResponse, options: new JsonSerializerOptions
                    {
                        WriteIndented = true
                    }));
                    return (object)errorResponse;
                case HttpStatusCode.Unauthorized:
                    errorResponse = new InvestecOpenApiErrorResponse(nameof(ErrorEnum.OperationRefused), await response.Content.ReadAsStringAsync());
                    this._logger.LogError("The requested operation will not be carried out {0}", JsonSerializer.Serialize(errorResponse, options: new JsonSerializerOptions
                    {
                        WriteIndented = true
                    }));
                    return (object)errorResponse;
                case HttpStatusCode.InternalServerError:
                    errorResponse = new InvestecOpenApiErrorResponse(nameof(ErrorEnum.OperationFailed), await response.Content.ReadAsStringAsync());
                    this._logger.LogError("The requested operation will not be carried out {0}", JsonSerializer.Serialize(errorResponse, options: new JsonSerializerOptions
                    {
                        WriteIndented = true
                    }));
                    return (object)errorResponse;
                default:
                    errorResponse = new InvestecOpenApiErrorResponse(nameof(ErrorEnum.UnknownErrorOccurred), await response.Content.ReadAsStringAsync());
                    this._logger.LogError("The requested operation will not be carried out {0}", JsonSerializer.Serialize(errorResponse, options: new JsonSerializerOptions
                    {
                        WriteIndented = true
                    }));
                    return (object)errorResponse;
            }
        }

        private async Task<string> GetAuthorizationTokenAsync()
        {
            string response = await _cache.GetOrCreateAsync("AuthAccessToken",async o => 
            {
                object tokenResponse = await this.RequestAuthTokenAsync();

                if (tokenResponse is AccessTokenResponse token) 
                {
                    o.SetAbsoluteExpiration(TimeSpan.FromSeconds(token.ExpiresIn - token.ExpiresIn * 0.1));
                    return $"{token.TokenType} {token.AccessToken}";
                }

                o.SetAbsoluteExpiration(TimeSpan.FromSeconds(1));
                throw new Exception("GetAuthorizationTokenAsync Failed");
            });

            return response;
        }
    }
}
