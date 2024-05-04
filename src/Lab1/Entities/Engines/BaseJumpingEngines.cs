using Itmo.ObjectOrientedProgramming.Lab1.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public abstract class BaseJumpingEngines
{
    private readonly double _fuelconsumptionrate;

    protected BaseJumpingEngines(double startFuel, double fuelConsumptionRate)
    {
        if (startFuel * fuelConsumptionRate < 0) throw new PositiveArgumentException("Can be only positive");

        StartFuel = startFuel;
        _fuelconsumptionrate = fuelConsumptionRate;
    }

    public double StartFuel { get; init; }
    public abstract double CalculateTime(int distance);

    public virtual double CalculateFuelConsumption(double time) => time * _fuelconsumptionrate;
}