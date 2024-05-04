using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

public class FileDeleteCommand : ICommandFileManager
{
    private readonly string _address;
    private readonly Context _context;

    public FileDeleteCommand(Context context, string address)
    {
        _address = Path.Combine(context?.Address ?? string.Empty, address);
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public void Execute()
    {
        _context.FileSystem.Delete(_address);
    }
}