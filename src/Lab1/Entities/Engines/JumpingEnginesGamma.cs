using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public class JumpingEnginesGamma : BaseJumpingEngines
{
    private const double FuelConsumptionRate = 3;
    private const double FuelForStart = 0.5;

    public JumpingEnginesGamma()
    : base(FuelForStart, FuelConsumptionRate)
    {
    }

    public override double CalculateTime(int distance) => distance / Math.Log(distance);
}