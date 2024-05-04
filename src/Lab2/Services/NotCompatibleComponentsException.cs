using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class NotCompatibleComponentsException : Exception
{
    public NotCompatibleComponentsException(string message)
        : base(message)
    {
    }

    public NotCompatibleComponentsException()
    {
    }

    public NotCompatibleComponentsException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}