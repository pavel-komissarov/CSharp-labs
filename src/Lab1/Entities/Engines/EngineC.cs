namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public class EngineC : BaseSimpleEngines
{
    private const double Speed = 5;
    private const double FuelConsumptionRate = 2;
    private const double FuelForStart = 0.1;

    public EngineC()
        : base(FuelForStart, FuelConsumptionRate)
    {
    }

    public override double CalculateTime(int distance) => distance / Speed;
}