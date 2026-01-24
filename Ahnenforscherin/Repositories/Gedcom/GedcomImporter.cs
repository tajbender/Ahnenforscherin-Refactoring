using Ahnenforscherin.Models;
using Ahnenforscherin.Repositories.Gedcom;
using System;
using System.IO;

namespace Ahnenforscherin.Repositories.Gedcom;

public class GedcomImporter
{
    private readonly IPersonRepository _personRepo;

    public GedcomImporter(IPersonRepository personRepo)
    {
        _personRepo = personRepo;
    }

    public void Import(string filePath)
    {
        var lines = File.ReadAllLines(filePath);

        foreach (var line in lines)
        {
            var record = GedcomLineParser.Parse(line);
            if (record == null)
                continue;

            DispatchRecord(record);
        }
    }

    private void DispatchRecord(GedcomRecord record)
    {
        switch (record.Tag)
        {
            case "INDI":
                HandleIndividual(record);
                break;

            case "FAM":
                HandleFamily(record);
                break;

            case "NOTE":
                HandleNote(record);
                break;

            case "SOUR":
                HandleSource(record);
                break;

            default:
                // Noch nicht implementiert
                break;
        }
    }

    private void HandleIndividual(GedcomRecord record)
    {
        // Dummy: später echte Logik
        var person = new Person
        {
            Id = record.Pointer ?? Guid.NewGuid().ToString()
        };

        _personRepo.Add(person);
    }

    private void HandleFamily(GedcomRecord record)
    {
        // TODO: später FamilyRepository
    }

    private void HandleNote(GedcomRecord record)
    {
        // TODO: Notes sammeln
    }

    private void HandleSource(GedcomRecord record)
    {
        // TODO: Quellen sammeln
    }
}