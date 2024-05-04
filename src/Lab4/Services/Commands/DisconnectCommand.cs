using Itmo.ObjectOrientedProgramming.Lab4.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

public class DisconnectCommand : ICommandFileManager
{
    private readonly Context _context;

    public DisconnectCommand(Context context)
    {
        _context = context;
    }

    public void Execute()
    {
        _context.SetFileSystem(new NullFileSystem());
        _context.TreeGoto(string.Empty);
    }
}