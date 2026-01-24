using Ahnenforscherin.Repositories;
using Ahnenforscherin.ViewModels;
using Microsoft.UI.Xaml.Controls;

namespace Ahnenforscherin.Views;

public sealed partial class PersonListPage : Page
{
    public PersonListViewModel ViewModel { get; }

    public PersonListPage()
    {
//        this.InitializeComponent();

        // Repository instanzieren oder DI verwenden
        var repo = new InMemoryPersonRepository();

        // Dummy-Daten laden
        foreach (var p in Models.PersonFactory.CreateSampleFamily())
            repo.Add(p);

        ViewModel = new PersonListViewModel(repo);
    }
}
