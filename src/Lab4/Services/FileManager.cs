using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Parsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services;

public class FileManager
{
    private Context _context;
    private IParser _parser;

    public FileManager(Context context, IParser? parser)
    {
        _context = context;
        _parser = parser ?? throw new ArgumentNullException(nameof(parser));
    }

    // Do not run this method in tests!!!
    public void StartApp()
    {
        while (true)
        {
            _context.Writer.Write("Enter command: ");
            string? command = Console.ReadLine();
            if (command == "exit")
            {
                break;
            }

            ICommandFileManager? commandFileManager =
                _parser.Parse(_context, command ?? throw new ArgumentNullException("command"));
            commandFileManager?.Execute();
        }
    }
}