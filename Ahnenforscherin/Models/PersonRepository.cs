using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ahnenforscherin.Models;

public class PersonRepository : IPersonRepository
{
    private readonly AppDbContext _context;
    //
    //    public PersonRepository(AhnenContext context)
    //    {
    //        _context = context;
    //    }

    //    public Task<List<Person>> GetAllAsync()
    //        => _context.Personen.ToListAsync();

    public Task<Person?> GetByIdAsync(int id)
        => _context.Personen.FindAsync(id).AsTask();

    public async Task AddAsync(Person person)
    {
        await _context.Personen.AddAsync(person);
    }

    public Task SaveChangesAsync()
        => _context.SaveChangesAsync();

    public Person? GetById(string id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Person> GetAll()
    {
        throw new NotImplementedException();
    }

    public void Add(Person person)
    {
        throw new NotImplementedException();
    }

    public void Update(Person person)
    {
        throw new NotImplementedException();
    }

    public void Delete(string id)
    {
        throw new NotImplementedException();
    }
}
