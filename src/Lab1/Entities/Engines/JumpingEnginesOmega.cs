using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public class JumpingEnginesOmega : BaseJumpingEngines
{
    private const double FuelConsumptionRate = 3;
    private const double FuelForStart = 0.5;

    public JumpingEnginesOmega()
        : base(FuelForStart, FuelConsumptionRate)
    {
        StartFuel = FuelForStart;
    }

    public override double CalculateTime(int distance)
    {
        return Math.Sqrt(distance);
    }
}