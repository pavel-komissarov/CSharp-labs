namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;

public class NullDeflector : BaseDeflector
{
    private const int DefaultAsteroids = 0;
    private const int DefaultMeteortids = 0;
    private const int DefaultWholses = 0;
    private const int DefaultReflects = 0;

    public NullDeflector()
    {
        CountAsteroids = DefaultAsteroids;
        CountMeteorites = DefaultMeteortids;
        CountWhales = DefaultWholses;
        Reflects = DefaultReflects;
    }
}