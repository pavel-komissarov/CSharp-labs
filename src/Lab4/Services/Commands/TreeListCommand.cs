using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

public class TreeListCommand : ICommandFileManager
{
    private readonly Context _context;
    private readonly int _depth;

    public TreeListCommand(Context context, int depth = 1)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _depth = depth < 0 ? 0 : depth;
    }

    public void Execute()
    {
        _context.Writer.Write(_context.FileSystem.TreeList(_context.WriterTree, _context.Address, _depth));
    }
}