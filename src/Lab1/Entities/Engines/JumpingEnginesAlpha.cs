namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public class JumpingEnginesAlpha : BaseJumpingEngines
{
    private const double Velocity = 5.0;
    private const double FuelConsumptionRate = 3;
    private const double FuelForStart = 0.5;

    public JumpingEnginesAlpha()
        : base(FuelForStart, FuelConsumptionRate)
    {
    }

    public override double CalculateTime(int distance) => distance / Velocity;
}