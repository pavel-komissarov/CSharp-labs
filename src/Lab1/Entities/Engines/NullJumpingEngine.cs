namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public class NullJumpingEngine : BaseJumpingEngines
{
    private const double NullTime = 0;
    private const double NullFuel = 1;
    private const double FuelForStart = 0;

    public NullJumpingEngine()
        : base(FuelForStart, NullFuel)
    {
        StartFuel = FuelForStart;
    }

    public override double CalculateTime(int distance) => NullTime;

    public override double CalculateFuelConsumption(double time) => NullFuel;
}