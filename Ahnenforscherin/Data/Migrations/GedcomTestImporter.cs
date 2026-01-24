using Ahnenforscherin.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahnenforscherin.Data.Migrations;

public class GedcomTestImporter
{
    public IEnumerable<Person> Import(string path)
    {
        var persons = new List<Person>();
        Person current = null;

        foreach (var line in File.ReadLines(path))
        {
            if (line.Contains("0 @I"))
            {
                if (current != null)
                    persons.Add(current);

                current = new Person();
            }

            if (line.StartsWith("1 NAME") && current != null)
            {
                var parts = line.Substring(7).Split('/');
                current.FirstName = parts[0].Trim();
                current.LastName = parts.Length > 1 ? parts[1].Trim() : "";
            }

            if (line.StartsWith("2 DATE") && current != null)
            {
                var dateString = line.Substring(7).Trim();
                if (DateTime.TryParse(dateString, out var date))
                    current.BirthDate = date;
            }
        }

        if (current != null)
            persons.Add(current);

        return persons;
    }
}
