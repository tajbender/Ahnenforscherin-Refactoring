using Ahnenforscherin.ViewModels;
using Microsoft.UI.Xaml.Controls;

namespace Ahnenforscherin.Views;

public sealed partial class MainPage : Page
{
    public MainViewModel ViewModel
    {
        get;
    }

    public MainPage()
    {
//        ViewModel = App.GetService<MainViewModel>();
        InitializeComponent();
    }
}
