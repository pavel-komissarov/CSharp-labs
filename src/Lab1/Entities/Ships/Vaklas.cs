using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Resistances;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

public class Vaklas : BaseShip
{
    public Vaklas(int simpleFuel = 0, int jumpingFuel = 0, bool photonicDeflector = false)
    {
        if (simpleFuel < 0)
        {
            throw new ArgumentException("Can`t be negative", nameof(simpleFuel));
        }

        if (jumpingFuel < 0)
        {
            throw new ArgumentException("Can`t be negative", nameof(jumpingFuel));
        }

        Deflector = new DeflectorOne();
        Resistence = new Resistance2();
        SimpleEngine = new EngineE();
        JumpingEnginie = new JumpingEnginesGamma();
        Dimensions = Dimensions.Middle;
        PhotonicDeflectors = photonicDeflector ? new PhotonicDeflector() : new NullPhotonicDeflector();
        Reflector = new NullReflector();
        SimpleFuel = simpleFuel;
        JumpingFuel = jumpingFuel;

        MaxArmor = Armory = Deflector.CountAsteroids + Resistence.CountAsteroids;
    }

    public override BaseDeflector Deflector { get; init; }
    public override BaseResistances Resistence { get; init; }
    public override BaseSimpleEngines SimpleEngine { get; init; }
    public override BaseJumpingEngines JumpingEnginie { get; init; }
    public override BasePhotonycDeflector PhotonicDeflectors { get; init; }
    public override BaseReflector Reflector { get; init; }
}