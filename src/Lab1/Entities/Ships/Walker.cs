using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Resistances;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

public class Walker : BaseShip
{
    public Walker(int simpleFuel, bool photonicDeflector = false)
    {
        if (simpleFuel < 0)
        {
            throw new ArgumentException("Can`t be negative", nameof(simpleFuel));
        }

        Deflector = new NullDeflector();
        Resistence = new Resistance1();
        SimpleEngine = new EngineC();
        JumpingEnginie = new NullJumpingEngine();
        Dimensions = Dimensions.Small;
        PhotonicDeflectors = photonicDeflector ? new PhotonicDeflector() : new NullPhotonicDeflector();
        Reflector = new NullReflector();
        SimpleFuel = simpleFuel;
        JumpingFuel = 0;

        // here it is advisable since these values do not even exceed 100
        MaxArmor = Armory = Deflector.CountAsteroids + Resistence.CountAsteroids;
    }

    public override BaseDeflector Deflector { get; init; }
    public override BaseResistances Resistence { get; init; }
    public override BaseSimpleEngines SimpleEngine { get; init; }
    public override BaseJumpingEngines JumpingEnginie { get; init; }
    public override BasePhotonycDeflector PhotonicDeflectors { get; init; }
    public override BaseReflector Reflector { get; init; }
}