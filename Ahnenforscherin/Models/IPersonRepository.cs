namespace Ahnenforscherin.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

public interface IPersonRepository
{
    Person? GetById(string id);
    IEnumerable<Person> GetAll();
    void Add(Person person);
    void Update(Person person);
    void Delete(string id);

    //Task<List<Person>> GetAllAsync();
    Task<Person?> GetByIdAsync(int id);
    Task AddAsync(Person person);
    Task SaveChangesAsync();
}
