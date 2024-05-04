using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public class EngineE : BaseSimpleEngines
{
    private const double AccelerationRate = 1;
    private const double FuelConsumptionRate = 3;
    private const double FuelForStart = 0.5;

    public EngineE()
        : base(FuelForStart, FuelConsumptionRate)
    {
    }

    public override double CalculateTime(int distance)
    {
        return Math.Log(1 + (distance * AccelerationRate)) / AccelerationRate;
    }
}