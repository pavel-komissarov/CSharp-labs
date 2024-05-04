using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

public class FileRenameCommand : ICommandFileManager
{
    private readonly string _address;
    private readonly string _newName;
    private readonly Context _context;

    public FileRenameCommand(Context context, string address, string newName)
    {
        _address = Path.Combine(context?.Address ?? string.Empty, address);
        _newName = newName;
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public void Execute()
    {
        _context.FileSystem.Rename(_address, _newName);
    }
}