namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;

public class DeflectorOne : BaseDeflector
{
    private const int DefaultAsteroids = 2;
    private const int DefaultMeteortids = 1;
    private const int DefaultWholses = 0;
    private const int DefaultReflects = 0;
    private const int ReflectsWithExtra = 3;

    public DeflectorOne(bool hasReflect = false)
    {
        CountAsteroids = DefaultAsteroids;
        CountMeteorites = DefaultMeteortids;
        CountWhales = DefaultWholses;
        Reflects = hasReflect ? ReflectsWithExtra : DefaultReflects;
    }
}