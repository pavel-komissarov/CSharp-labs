using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

public class FileShowCommand : ICommandFileManager
{
    private readonly Context _context;
    private readonly string _address;

    public FileShowCommand(Context context, string address)
    {
        _context = context;
        _address = Path.Combine(context?.Address ?? string.Empty, address);
    }

    public void Execute()
    {
        _context.Writer.Write(_context.FileSystem.ShowFile(_address));
    }
}