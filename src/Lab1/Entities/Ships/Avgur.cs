using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Resistances;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

public class Avgur : BaseShip
{
    public Avgur(int simpleFuel = 0, int jumpingFuel = 0, bool photonicDeflector = false)
    {
        if (simpleFuel < 0)
        {
            throw new ArgumentException("Can`t be negative", nameof(simpleFuel));
        }

        if (jumpingFuel < 0)
        {
            throw new ArgumentException("Can`t be negative", nameof(jumpingFuel));
        }

        Deflector = new DeflectorThree();
        Resistence = new Resistance3();
        SimpleEngine = new EngineE();
        JumpingEnginie = new JumpingEnginesAlpha();
        Dimensions = Dimensions.Large;
        PhotonicDeflectors = photonicDeflector ? new PhotonicDeflector() : new NullPhotonicDeflector();
        Reflector = new NullReflector();
        SimpleFuel = simpleFuel;
        JumpingFuel = jumpingFuel;

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