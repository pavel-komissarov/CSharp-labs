using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Parsers;

public class ConnectParser : IParser
{
    private readonly IFileSystemsFabrics? _fabrics;
    private IParser? _nextParser;

    public ConnectParser(IFileSystemsFabrics fabrics)
    {
        _fabrics = fabrics;
    }

    public IParser SetNext(IParser parser)
    {
        _nextParser = parser;
        return parser;
    }

    public ICommandFileManager? Parse(Context context, string input)
    {
        if (string.IsNullOrEmpty(input)) return null;

        string[] parts = input.Split(' ');

        if (parts.Length >= 3 && parts[0] == "connect" && parts[2] == "-m")
        {
            return new ConnectCommand(
                context,
                _fabrics?.CreateFileSystem(parts[3]) ?? throw new FileSystemWasntSetException(),
                parts[1]);
        }

        return _nextParser?.Parse(context, input);
    }
}