using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public class PositiveArgumentException : Exception
{
    public PositiveArgumentException(string message)
        : base(message)
    {
    }

    public PositiveArgumentException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public PositiveArgumentException()
    {
    }
}