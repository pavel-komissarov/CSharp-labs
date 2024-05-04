using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

public class TreeGotoCommand : ICommandFileManager
{
    private readonly string _address;
    private readonly Context _context;

    public TreeGotoCommand(Context context, string address)
    {
        _address = Path.Combine(context?.Address ?? string.Empty, address);
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public void Execute()
    {
        _context.TreeGoto(_address);
    }
}