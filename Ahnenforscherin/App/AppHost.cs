using Ahnenforscherin.Services;
using System;
using System.Threading.Tasks;

public sealed class AppHost
{
    public IServiceProvider Services { get; }

    public AppHost()
    {
        //var services = new ServiceCollection();

        //// 1) Configuration
        //var config = new ConfigurationBuilder()
        //    .AddJsonFile("appsettings.json", optional: true)
        //    .Build();
        //services.AddSingleton<IConfiguration>(config);

        //// 2) Services
        //services.AddAppServices();
        //services.AddDatabase(config);
        //services.AddNavigation();
        //services.AddThemeService();

        //Services = services.BuildServiceProvider();
    }

    public async Task InitializeAsync()
    {
        // 3) DB Setup

        //var dbInit = Services.GetRequiredService<DatabaseInitializer>();
        //await dbInit.InitializeAsync();

        //// 4) Theme laden
        //var theme = Services.GetRequiredService<ThemeService>();
        //theme.LoadTheme();
    }
}
