using dotnetstarter.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public class Startup
{
    static public IConfigurationRoot Configuration { get; set; }

    public Startup(IHostingEnvironment env)
    {
        // Set up configuration sources.
        var builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("vcap_services.json", optional: true, reloadOnChange: true);

        Configuration = builder.Build();
    }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        // Add framework services.
        //services.AddApplicationInsightsTelemetry(Configuration);

        services.AddOptions();

        services.Configure<LanguageTranslatorOptions>(options => Configuration.GetSection("language-translator").Bind(options));

        services.AddMvc();
    }

    public void Configure(IApplicationBuilder app)
	{
		app.UseDefaultFiles();
		app.UseStaticFiles();
        app.UseBrowserLink();

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
