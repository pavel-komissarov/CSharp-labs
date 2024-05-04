using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Resistances;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

public abstract class BaseShip
{
    public abstract BaseDeflector Deflector { get; init; }
    public abstract BaseResistances Resistence { get; init; }
    public abstract BaseSimpleEngines SimpleEngine { get; init; }
    public abstract BaseJumpingEngines JumpingEnginie { get; init; }
    public abstract BasePhotonycDeflector PhotonicDeflectors { get; init; }
    public abstract BaseReflector Reflector { get; init; }
    public Dimensions Dimensions { get; init; }

    public double Time { get; private set; }
    public double MaxArmor { get; protected init; }
    public double Armory { get; protected set; }
    public double SimpleFuel { get; protected set; }
    public double JumpingFuel { get; protected set; }

    public void TakeDamage(double damage, int count)
    {
        if (count < 0)
        {
            throw new ArgumentException("Must be positive", nameof(count));
        }

        Armory -= damage * count;
    }

    public void CountTimeSimpleFuel(int distance, int coefficient = 1)
    {
        double time = SimpleEngine.CalculateTime(distance);
        Time += time * coefficient;
        SimpleFuel -= (SimpleEngine.CalculateFuelConsumption(time) + SimpleEngine.StartFuel) * coefficient;
    }

    public void CountTimeJumpingFuel(int distance)
    {
        double time = JumpingEnginie.CalculateTime(distance);
        Time += time;
        JumpingFuel -= JumpingEnginie.CalculateFuelConsumption(time) + JumpingEnginie.StartFuel;
    }
}