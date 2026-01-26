using Ahnenforscherin.Models;
using Ahnenforscherin.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.UI.Xaml.Shapes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Ahnenforscherin;

/// <summary>
/// Provides application-specific behavior to supplement the default Application class.
/// </summary>
public partial class App : Application
{
    private Window? _window;
    public static AppHost Host { get; private set; }

    public Window MainWindow  { get; private set; }

    public static IServiceProvider Services { get; private set; }

    /// <summary>
    /// Initializes the singleton application object.  This is the first line of authored code
    /// executed, and as such is the logical equivalent of main() or WinMain().
    /// </summary>
    public App()
    {
        //InitializeComponent();
        Host = new AppHost();

        var services = new ServiceCollection();
        _ = services.AddDbContext<AppDbContext>(static options =>
        {
            //options.UseSqlite("Data Source=ahnenforscherin.db");
        });

        _ = services.AddScoped<IPersonRepository, PersonRepository>();

        Services = services.BuildServiceProvider();


//        var builder = Host.CreateApplicationBuilder();
//
//        builder.Services.AddDbContext<AppDbContext>(options =>
//        {
//            options.UseSqlite("Data Source=ahnenforscherin.db");
//        });
//
//        builder.Services.AddScoped<IPersonRepository, PersonRepository>();
//
//        var host = builder.Build();
//        Services = host.Services;
//
//        InitializeComponent();


    }

    /// <summary>
    /// Invoked when the application is launched.
    /// </summary>
    /// <param name="args">Details about the launch request and process.</param>
    protected override async void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
    {
        await Host.InitializeAsync();
        // TODO: Error: IServiceProvider?: var navigationService = Host.Services.GetRequiredService<NavigationService>();

        _window = new MainWindow();
        _window.Activate();
        this.MainWindow = _window;

        //var test = var mainWindow = (MainWindow)App.Current.MainWindow;

    }
}
