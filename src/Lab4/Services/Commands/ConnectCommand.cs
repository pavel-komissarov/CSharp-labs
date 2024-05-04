using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

public class ConnectCommand : ICommandFileManager
{
    private readonly string _address;
    private readonly Context _context;
    private readonly IFileSystem _fileSystem;

    public ConnectCommand(Context context, IFileSystem fileSystem, string address)
    {
        _address = Path.Combine(context?.Address ?? string.Empty, address);
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _fileSystem = fileSystem;
    }

    public void Execute()
    {
        _context.SetFileSystem(_fileSystem);
        _context.TreeGoto(_address);
    }
}