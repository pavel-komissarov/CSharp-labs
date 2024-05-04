using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Parsers;

public class DisconnectParser : IParser
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

        if (parts.Length >= 1 && parts[0] == "disconnect")
        {
            return new DisconnectCommand(context);
        }

        return _nextParser?.Parse(context, input);
    }
}