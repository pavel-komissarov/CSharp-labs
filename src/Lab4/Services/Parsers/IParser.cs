using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Parsers;

public interface IParser
{
    IParser SetNext(IParser parser);
    public ICommandFileManager? Parse(Context context, string input);
}