using System;
using System.Collections.Generic;

namespace Ahnenforscherin.Models;

public static class PersonFactory
{
    public static Person CreateDummy(string first, string last, int birthYear, int? deathYear = null)
    {
        return new Person
        {
            FirstName = first,
            LastName = last,
            BirthDate = new DateTime(birthYear, 1, 1),
            DeathDate = deathYear.HasValue ? new DateTime(deathYear.Value, 1, 1) : null,
            Sex = Gender.Unknown,
        };
    }

    public static List<Person> CreateSampleFamily()
    {
        var father = CreateDummy("Johann", "Müller", 1950);
        father.Sex = Gender.Male;

        var mother = CreateDummy("Anna", "Müller", 1955);
        mother.Sex = Gender.Female;

        var child1 = CreateDummy("Klara", "Müller", 1980);
        child1.Sex = Gender.Female;

        var child2 = CreateDummy("Markus", "Müller", 1983);
        child2.Sex = Gender.Male;

        // Beziehungen setzen
        child1.ParentIds.Add(father.Id);
        child1.ParentIds.Add(mother.Id);

        child2.ParentIds.Add(father.Id);
        child2.ParentIds.Add(mother.Id);

        father.ChildIds.Add(child1.Id);
        father.ChildIds.Add(child2.Id);

        mother.ChildIds.Add(child1.Id);
        mother.ChildIds.Add(child2.Id);

        father.SpouseIds.Add(mother.Id);
        mother.SpouseIds.Add(father.Id);

        return [father, mother, child1, child2];
    }
}