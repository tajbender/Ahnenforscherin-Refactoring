namespace Ahnenforscherin.Models;

using System.Collections.Generic;

public interface IPersonRepository
{
    Person? GetById(string id);
    IEnumerable<Person> GetAll();
    void Add(Person person);
    void Update(Person person);
    void Delete(string id);
}