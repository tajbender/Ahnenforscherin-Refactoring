using Ahnenforscherin.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahnenforscherin.Data;

public static class ServiceCollectionExtensions
{
    //public static IServiceCollection AddAppServices(this IServiceCollection services)
    //{
    //    services.AddSingleton<IPersonService, PersonService>();
    //    services.AddSingleton<ITreeService, TreeService>();
    //    return services;
    //}

    //public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration config)
    //{
    //    var dbPath = config["Database:Path"] ?? "Data/Ahnenforscherin.db";

    //    services.AddDbContext<AppDbContext>(options =>
    //        options.UseSqlite($"Data Source={dbPath}"));

    //    services.AddSingleton<DatabaseInitializer>();
    //    return services;
    //}

    //public static IServiceCollection AddNavigation(this IServiceCollection services)
    //{
    //    services.AddSingleton<NavigationService>();
    //    return services;
    //}

    //public static IServiceCollection AddThemeService(this IServiceCollection services)
    //{
    //    services.AddSingleton<ThemeService>();
    //    return services;
    //}
}
