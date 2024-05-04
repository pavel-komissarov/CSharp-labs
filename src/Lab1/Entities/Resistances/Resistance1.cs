namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Resistances;

public class Resistance1 : BaseResistances
{
    private const int DefaultAsteroids = 1;
    private const int DefaultMeteortids = 0;

    public Resistance1()
    {
        CountAsteroids = DefaultAsteroids;
        CountMeteortids = DefaultMeteortids;
    }
}