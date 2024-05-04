namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;

public abstract class BaseDeflector
{
    public uint CountAsteroids { get; init; }
    public uint CountMeteorites { get; init; }
    public uint CountWhales { get; init; }

    public int Reflects { get; init; }
}