using NewsRead.Services.Services;
using Serilog;

namespace NewsRead.API;

public class Startup
{
	public IConfiguration Configuration { get; }

	public Startup(IConfiguration configuration)
	{
		Configuration = configuration;
	}

	public void ConfigureServices(IServiceCollection services)
	{
		var newsUrl = Configuration.GetConnectionString("News_URL");
		services.AddMvc(a => { a.EnableEndpointRouting = false; });
		services.AddMemoryCache();
		services.AddTransient<IReadNews, ReadNews>();
		services.AddTransient<IFetchNews, FetchNews>();
		services.AddControllers();

		var logger = new Serilog.LoggerConfiguration()
		   .WriteTo.File($"Logs/NewsReadAPI.log", rollingInterval: RollingInterval.Day)
		   .CreateLogger();
		Serilog.Log.Logger = logger;
		services.AddSingleton<Serilog.ILogger>(logger);

		services.AddHttpClient<IReadNews, ReadNews>("newsUrl", httpClient =>
		{
			httpClient.BaseAddress = new Uri(newsUrl);
			httpClient.DefaultRequestHeaders.Accept.Clear();
			httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
		});

		services.AddSwaggerGen(config =>
		{
			config.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
			{
				Title = "News Read API",
				Version = "v1",
			});
		});
	}

	public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
	{
		app.UseMvc();
		app.UseSwagger();
		app.UseSwaggerUI(config =>
		{
			config.SwaggerEndpoint("/swagger/v1/swagger.json", "News Read API(v1)");
		});
	}
}
