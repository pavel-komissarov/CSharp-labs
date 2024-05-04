using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Exceptions;

public class FileSystemWasntSetException : IOException
{
    public FileSystemWasntSetException(string message)
        : base(message)
    {
    }

    public FileSystemWasntSetException()
    {
    }

    public FileSystemWasntSetException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }
}