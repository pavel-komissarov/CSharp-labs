using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services;

public class MessageCantBeReadException : IOException
{
    public MessageCantBeReadException(string message)
        : base(message)
    {
    }

    public MessageCantBeReadException()
    {
    }

    public MessageCantBeReadException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }
}