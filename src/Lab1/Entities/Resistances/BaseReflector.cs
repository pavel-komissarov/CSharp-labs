namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Resistances;

public abstract class BaseReflector
{
    public bool HasReflector { get; protected set; }

    public void UseReflector() => HasReflector = false;
}