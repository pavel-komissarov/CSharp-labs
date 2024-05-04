using System.Globalization;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Parsers;

public class TreeListParser : IParser
{
    private IParser? _nextParser;

    public IParser SetNext(IParser parser)
    {
        _nextParser = parser;
        return parser;
    }

    public ICommandFileManager? Parse(Context context, string input)
    {
        if (string.IsNullOrWhiteSpace(input)) return null;

        string[] parts = input.Split(' ');

        if (parts.Length >= 2 && parts[0] == "tree" && parts[1] == "list")
        {
            return new TreeListCommand(
                context,
                (parts.Length > 2 && parts[2] == "-d" && int.TryParse(parts[3], out int depth) && depth >= 0) ? int.Parse(parts[3], CultureInfo.InvariantCulture) : 1);
        }

        return _nextParser?.Parse(context, input);
    }
}