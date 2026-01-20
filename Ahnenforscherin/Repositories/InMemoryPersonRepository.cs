using Ahnenforscherin.Models;
using System.Collections.Generic;

namespace Ahnenforscherin.Repositories;

public class InMemoryPersonRepository : IPersonRepository
{
    private readonly Dictionary<string, Person> _persons = [];

    public Person? GetById(string id)
    {
        _persons.TryGetValue(id, out var person);
        return person;
    }

    public IEnumerable<Person> GetAll()
    {
        return _persons.Values;
    }

    public void Add(Person person)
    {
        if (!_persons.ContainsKey(person.Id))
            _persons[person.Id] = person;
    }

    public void Update(Person person)
    {
        if (_persons.ContainsKey(person.Id))
            _persons[person.Id] = person;
    }

    public void Delete(string id)
    {
        _persons.Remove(id);
    }
}