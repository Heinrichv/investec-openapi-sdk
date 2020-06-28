using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Investec.Sdk.OpenApi.Clients
{
    public interface IInvestecOpenApiService
    {
        Task<object> RequestAuthTokenAsync();

        Task<object> GetAccountsAsync();

        Task<object> GetAccountTransactionsAsync(string accountId);

        Task<object> GetAccountBalanceAsync(string accountId);
    }
}
