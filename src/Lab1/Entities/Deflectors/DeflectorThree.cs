namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;

public class DeflectorThree : BaseDeflector
{
    private const int DefaultAsteroids = 40;
    private const int DefaultMeteortids = 10;
    private const int DefaultWholses = 1;
    private const int DefaultReflects = 0;
    private const int ReflectsWithExtra = 3;

    public DeflectorThree(bool hasReflect = false)
    {
        CountAsteroids = DefaultAsteroids;
        CountMeteorites = DefaultMeteortids;
        CountWhales = DefaultWholses;
        Reflects = hasReflect ? ReflectsWithExtra : DefaultReflects;
    }
}