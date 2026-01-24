using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahnenforscherin.Services;

internal class ThemeService
{
    //private readonly IConfiguration _config;

    //public ThemeService(IConfiguration config)
    //{
    //    _config = config;
    //}


    void SetTheme(string themeName)
    {
        //var themeNames = _config["Theme"] ?? "Fluent";


        var dictionaries = Application.Current.Resources.MergedDictionaries;
        dictionaries.Clear();

        dictionaries.Add(new ResourceDictionary { Source = new Uri($"ms-appx:///Themes/{themeName}/Colors.xaml") });
        dictionaries.Add(new ResourceDictionary { Source = new Uri($"ms-appx:///Themes/{themeName}/Icons.xaml") });
        dictionaries.Add(new ResourceDictionary { Source = new Uri($"ms-appx:///Themes/{themeName}/Styles.xaml") });
    }

    public void test()
    {
        SetTheme("Fluent");
        SetTheme("Material");
        SetTheme("Indy");
    }
}
