using Ahnenforscherin.Models;
using Ahnenforscherin.Repositories;
using Microsoft.UI.Xaml.Controls;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Ahnenforscherin.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class WorkbenchPage : Page
    {
        public WorkbenchPage()
        {
            InitializeComponent();

            var repo = new InMemoryPersonRepository();
            var dummies = PersonFactory.CreateSampleFamily();

            foreach (var p in dummies)
                repo.Add(p);
        }
    }
}
