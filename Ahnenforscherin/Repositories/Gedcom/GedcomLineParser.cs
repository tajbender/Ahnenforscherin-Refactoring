using System.Text.RegularExpressions;

namespace Ahnenforscherin.Repositories.Gedcom;



public class GedcomRecord
{
    public int Level { get; set; }
    public string? Pointer { get; set; }
    public string Tag { get; set; } = "";
    public string? Value { get; set; }
}
public static class GedcomLineParser
{
    private static readonly Regex LineRegex =
        new(@"^(?<level>\d+)\s+(?:(?<pointer>@[^@]+@)\s+)?(?<tag>[A-Z0-9_]+)(?:\s+(?<value>.*))?$");

    public static GedcomRecord? Parse(string line)
    {
        var match = LineRegex.Match(line);
        if (!match.Success)
            return null;

        return new GedcomRecord
        {
            Level = int.Parse(match.Groups["level"].Value),
            Pointer = match.Groups["pointer"].Success ? match.Groups["pointer"].Value : null,
            Tag = match.Groups["tag"].Value,
            Value = match.Groups["value"].Success ? match.Groups["value"].Value : null
        };
    }
}