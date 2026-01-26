using Ahnenforscherin.Services;
using Ahnenforscherin.Views;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Ahnenforscherin;

/// <summary>
/// An empty window that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        NavigationView.SelectedItem = NavigationView.MenuItems[0];
        ContentFrame.Navigate(typeof(WorkbenchPage));

        //NavigationService.Instance.Frame = ContentFrame;

    }

    private void NavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
    {
        try
        {
            if (args.IsSettingsSelected)
            {
                ContentFrame.Navigate(typeof(SettingsPage));
                return;
            }

            var item = (NavigationViewItem)args.SelectedItem;
            switch (item.Tag)
            {
                case "Workbench":
                    ContentFrame.Navigate(typeof(WorkbenchPage));
                    break;

                case "Personen":
                    ContentFrame.Navigate(typeof(PersonenPage));
                    break;

                case "Stammbaum":
                    ContentFrame.Navigate(typeof(StammbaumPage));
                    break;

                case "Migration":
                    ContentFrame.Navigate(typeof(MigrationPage));
                    break;

                default:
                    // TODO: Handle navigation to other pages here. Throw exception if tag is unknown.
                    break;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine("Navigation error: " + ex.Message);
        }
    }

    public void NavigateTo(string tag)
    {
        switch (tag)
        {
            case "Workbench":
                ContentFrame.Navigate(typeof(WorkbenchPage));
                break;

            case "Personen":
                ContentFrame.Navigate(typeof(PersonenPage));
                break;

            case "Stammbaum":
                ContentFrame.Navigate(typeof(StammbaumPage));
                break;

            case "Migration":
                ContentFrame.Navigate(typeof(MigrationPage));
                break;

            case "Settings":
                ContentFrame.Navigate(typeof(SettingsPage));
                break;
        }
    }
}
