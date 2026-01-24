using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahnenforscherin.Models;

public class Person
{
    public string Id { get; set; } = Guid.NewGuid().ToString();

    // Grunddaten
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? NickName { get; set; }

    public Gender Sex { get; set; } = Gender.Unknown;

    // Lebensdaten
    public DateTime? BirthDate { get; set; }
    public string? BirthPlace { get; set; }

    public DateTime? DeathDate { get; set; }
    public string? DeathPlace { get; set; }

    // Beziehungen
    public List<string> ParentIds { get; set; } = [];
    public List<string> ChildIds { get; set; } = [];
    public List<string> SpouseIds { get; set; } = [];

    // Lebensereignisse
    public List<LifeEvent> Events { get; set; } = [];

    // GEDCOM-spezifische Rohdaten (optional)
    public Dictionary<string, string> RawGedcomTags { get; set; } = [];
}

/// <summary>
/// Geschlecht laut GEDCOM: M, F, U 
/// </summary>
public enum Gender
{
    Unknown,
    Male,
    Female
}

public class LifeEvent
{
    public string Tag { get; set; } = "";
    public DateTime? Date { get; set; }
    public string? Place { get; set; }
    public string? Description { get; set; }
}

