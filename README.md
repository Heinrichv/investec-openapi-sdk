# investec-openapi-sdk
.NET Standard library to used to easily integrate with Investec's OpenAPI

## Getting Started With Dependency injection

#### Startup.cs

```c#
public class Startup 
{
	private readonly IConfiguration _configuration;

	public Startup(IConfiguration configuration) 
	{
		this._configuration = configuration;
	}

	public void ConfigureServices(IServiceCollection services)
	{
		services.AddMemoryCache();
		services.AddInvestecOpenApi(new InvestecOpenApiConfiguration
        {
            ClientId = "client_id",
            Secret = "secret",
            Url = "https://openapi.investec.com"
        });
	}
}
```

## Example

```c#
public class Example 
{
	private readonly IInvestecOpenApiService _investecopenApiService;
	private readonly ILogger<Example> _logger;

	public Example(IInvestecOpenApiService investecopenApiService, ILogger<Example> logger) 
	{
		this._investecopenApiService = investecopenApiService;
	}

	public async Task GetAccountsAsync()
	{
		object accounts = await this._investecopenApiService.GetAccountsAsync();

		if (accounts is InvestecResponse response)
		{
			this._logger.LogInformation("{0}", response)
		}
		else if (accounts is InvestecResponse errorResponse) 
		{
			this._logger.LogError("{0} {1}", response.Message, response);
		}
	}
}
```