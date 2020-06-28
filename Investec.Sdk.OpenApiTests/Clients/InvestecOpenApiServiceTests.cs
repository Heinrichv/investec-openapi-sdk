using Microsoft.VisualStudio.TestTools.UnitTesting;
using Investec.Sdk.OpenApi.Clients;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Investec.Sdk.OpenApi.Models.Response;
using System.Linq;

namespace Investec.Sdk.OpenApi.Clients.Tests
{
    [TestClass()]
    public class InvestecOpenApiServiceTests
    {
        private readonly IServiceProvider _serviceProvider;

        public InvestecOpenApiServiceTests()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddMemoryCache();
            services.AddInvestecOpenApi(new Models.InvestecOpenApiConfiguration 
            {
                Url = "https://openapi.investec.com",
                ClientId = "",
                Secret = ""
            });


            this._serviceProvider = services.BuildServiceProvider();
        }

        [TestMethod()]
        public async Task RequestAuthTokenAsyncTest()
        {
            IInvestecOpenApiService service = this._serviceProvider.GetService<IInvestecOpenApiService>();

            object serviceResponse = await service.RequestAuthTokenAsync();

            if (serviceResponse is AccessTokenResponse response)
            {
                Assert.IsNotNull(response.AccessToken);
            }
            else
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public async Task GetAccountsAsyncTest()
        {
            IInvestecOpenApiService service = this._serviceProvider.GetService<IInvestecOpenApiService>();

            object serviceResponse = await service.GetAccountsAsync();

            if (serviceResponse is InvestecResponse response)
            {
                Assert.IsNotNull(response.Data.Accounts);
            }
            else
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public async Task GetAccountTransactionsAsyncTest()
        {
            IInvestecOpenApiService service = this._serviceProvider.GetService<IInvestecOpenApiService>();
            
            object accountServiceResponse = await service.GetAccountsAsync();

            if (accountServiceResponse is InvestecResponse accountResponse)
            {
                object serviceResponse = await service.GetAccountTransactionsAsync(accountResponse.Data.Accounts.First().AccountId);

                if (serviceResponse is InvestecResponse response)
                {
                    Assert.IsNotNull(response.Data.Transactions);
                }
                else
                {
                    Assert.Fail();
                }
            }
            else
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public async Task GetAccountBalanceAsyncTest()
        {
            IInvestecOpenApiService service = this._serviceProvider.GetService<IInvestecOpenApiService>();

            object accountServiceResponse = await service.GetAccountsAsync();

            if (accountServiceResponse is InvestecResponse accountResponse)
            {
                object serviceResponse = await service.GetAccountBalanceAsync(accountResponse.Data.Accounts.First().AccountId);

                if (serviceResponse is InvestecBalanceResponse response)
                {
                    Assert.IsNotNull(response.Data);
                }
                else
                {
                    Assert.Fail();
                }
            }
            else
            {
                Assert.Fail();
            }
        }
    }
}