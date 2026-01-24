using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Ahnenforscherin
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            /*
            case "personlist":
                ContentFrame.Navigate(typeof(PersonListPage));
                break;
             */
        }

        private void SetStatus(string message)
        {
            StatusText.Text = message;
        }

        private void CreatePerson_Click(object sender, RoutedEventArgs e)
        {
            SetStatus("Neue Person anlegen (Dummy)...");
            // TODO: Navigation zu PersonEditor
        }

        private void OpenPersonList_Click(object sender, RoutedEventArgs e)
        {
            SetStatus("Personenliste öffnen (Dummy)...");
            // TODO: Navigation zu PersonList
        }

        private void ImportGedcom_Click(object sender, RoutedEventArgs e)
        {
            SetStatus("GEDCOM importieren (Dummy)...");
            // TODO: FilePicker + Parser
        }

        private void ExportGedcom_Click(object sender, RoutedEventArgs e)
        {
            SetStatus("GEDCOM exportieren (Dummy)...");
            // TODO: Exportfunktion
        }

        private void OpenTree_Click(object sender, RoutedEventArgs e)
        {
            SetStatus("Stammbaum öffnen (Dummy)...");
            // TODO: TreeView öffnen
        }

        private void CreateTree_Click(object sender, RoutedEventArgs e)
        {
            SetStatus("Neuen Stammbaum erstellen (Dummy)...");
            // TODO: Tree-Setup
        }

    }
}
