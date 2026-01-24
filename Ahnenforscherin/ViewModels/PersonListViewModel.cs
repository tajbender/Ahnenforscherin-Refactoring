using Ahnenforscherin.Models;
using System.Collections.ObjectModel;

namespace Ahnenforscherin.ViewModels;

public class PersonListViewModel
{
    public ObservableCollection<Person> Persons { get; } = new();

    public PersonListViewModel(IPersonRepository repo)
    {
        foreach (var p in repo.GetAll())
            Persons.Add(p);
    }
}