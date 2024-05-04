using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Parsers;

public class FileShowParser : IParser
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

        if (parts.Length >= 2 && parts[0] == "file" && parts[1] == "show"
            && parts[3] == "-m" && parts[4] == "console")
        {
            return new FileShowCommand(context, parts[2]);
        }

        return _nextParser?.Parse(context, input);
    }
}