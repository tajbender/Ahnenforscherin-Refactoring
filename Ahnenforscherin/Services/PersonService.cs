using Ahnenforscherin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahnenforscherin.Services;

class PersonService
{
    private readonly IRepository<Person> personService;
    public PersonService(IRepository<Person> personService)
    {
        this.personService = personService;
        InitTestData();
    }

    public void InitTestData() {
        personService.AddPerson(new Person
        {
            FirstName = "Anna",
            LastName = "Müller",
            BirthDate = new DateTime(1985, 4, 12)
        });

        personService.AddPerson(new Person
        {
            FirstName = "Karl",
            LastName = "Schneider",
            BirthDate = new DateTime(1978, 11, 3)
        });

    }

    public void AddPerson(Person person)
    {

    }

    public void UpdatePerson() { }
    public void DeletePerson() { }
    public void GetAll() { }
}