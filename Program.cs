using Microsoft.AspNetCore;

namespace NewsRead.API;

public class Program
{
	public static void Main(String[] args)
	{
		CreateWebHostBuilder(args).Build().Run();
	}

	private static IWebHostBuilder CreateWebHostBuilder(string[] args)
		=> WebHost.CreateDefaultBuilder(args).UseStartup<Startup>();
}