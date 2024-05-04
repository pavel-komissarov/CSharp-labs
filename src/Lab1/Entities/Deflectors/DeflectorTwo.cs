namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;

public class DeflectorTwo : BaseDeflector
{
    private const int DefaultAsteroids = 10;
    private const int DefaultMeteortids = 3;
    private const int DefaultWholses = 0;
    private const int DefaultReflects = 0;
    private const int ReflectsWithExtra = 3;

    public DeflectorTwo(bool hasReflect = false)
    {
        CountAsteroids = DefaultAsteroids;
        CountMeteorites = DefaultMeteortids;
        CountWhales = DefaultWholses;
        Reflects = hasReflect ? ReflectsWithExtra : DefaultReflects;
    }
}