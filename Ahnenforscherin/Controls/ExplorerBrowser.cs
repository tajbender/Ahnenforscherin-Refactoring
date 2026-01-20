using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Diagnostics;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Ahnenforscherin.Controls;

public sealed partial class ExplorerBrowser : Control
{
    public object DataSource
    {
        get { return (object)GetValue(DataSourceProperty); }
        set { SetValue(DataSourceProperty, value); }
    }
    public static readonly DependencyProperty DataSourceProperty =
        DependencyProperty.Register("DataSource", typeof(object), typeof(ExplorerBrowser), new PropertyMetadata(null));

    public ExplorerBrowser()
    {
        Debug.Print("ExplorerBrowser.ctor()");
        /* WARN: CA1416 This call site is reachable on all platforms. 'Control.DefaultStyleKey' is only supported on: 'Windows' 10.0.17763.0 and later. */
        DefaultStyleKey = typeof(ExplorerBrowser);

    }

    private void ExplorerBrowser_DataSourceChanged(object? sender, EventArgs e)
    {
        Debug.Print("ExplorerBrowser.DataSourceChanged()");
    }
}
