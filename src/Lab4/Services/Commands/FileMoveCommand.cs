using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

public class FileMoveCommand : ICommandFileManager
{
    private readonly string _addressFrom;
    private readonly string _addressTo;
    private readonly Context _context;

    public FileMoveCommand(Context context, string addressFrom, string addressTo)
    {
        _addressFrom = Path.Combine(context?.Address ?? string.Empty, addressFrom);
        _addressTo = Path.Combine(context?.Address ?? string.Empty, addressTo);
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public void Execute()
    {
        _context.FileSystem.Move(_addressFrom, _addressTo);
    }
}