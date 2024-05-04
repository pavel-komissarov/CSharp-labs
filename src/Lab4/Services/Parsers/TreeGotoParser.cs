using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Parsers;

public class TreeGotoParser : IParser
{
    private IParser? _nextParser;

    public IParser SetNext(IParser parser)
    {
        _nextParser = parser;
        return parser;
    }

    public ICommandFileManager? Parse(Context context, string input)
    {
        if (string.IsNullOrEmpty(input)) return null;

        string[] parts = input.Split(' ');

        if (parts.Length >= 2 && parts[0] == "tree" && parts[1] == "goto")
        {
            return new TreeGotoCommand(context, parts[2]);
        }

        return _nextParser?.Parse(context, input);
    }
}