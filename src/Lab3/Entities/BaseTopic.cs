using System;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public abstract class BaseTopic
{
    protected BaseTopic(string name)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }

    public string Name { get; init; }
    public abstract void SendMessage(BaseMessage baseMessage);
}