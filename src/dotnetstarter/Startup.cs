using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public class Startup
{

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        // Add framework services.
        //services.AddApplicationInsightsTelemetry(Configuration);

        services.AddMvc();
    }

    public void Configure(IApplicationBuilder app)
	{
		app.UseDefaultFiles();
		app.UseStaticFiles();

        app.UseMvc(routes =>
        {
            routes.MapRoute(
                   name: "default",
                   template: "{controller=Home}/{action=Index}/{id?}");
        });
    }

    public static void Main(string[] args)
    {
        var config = new ConfigurationBuilder()
            .AddCommandLine(args)
            .Build();

        var host = new WebHostBuilder()
                    .UseKestrel()
                    .UseConfiguration(config)
                    .UseStartup<Startup>()
                    .Build();
        host.Run();
    }
}
