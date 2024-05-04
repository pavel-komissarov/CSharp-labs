using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class ComponentNotFoundByNameException : Exception
{
    public ComponentNotFoundByNameException(string message)
        : base(message)
    {
    }

    public ComponentNotFoundByNameException()
    {
    }

    public ComponentNotFoundByNameException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}