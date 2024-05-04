using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Resistances;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

public class Meredian : BaseShip
{
    public Meredian(int simpleFuel = 0, bool photonicDeflector = false)
    {
        if (simpleFuel < 0)
        {
            throw new ArgumentException("Can`t be negative", nameof(simpleFuel));
        }

        Deflector = new DeflectorTwo();
        Resistence = new Resistance2();
        SimpleEngine = new EngineE();
        JumpingEnginie = new NullJumpingEngine();
        Dimensions = Dimensions.Middle;
        PhotonicDeflectors = photonicDeflector ? new PhotonicDeflector() : new NullPhotonicDeflector();
        Reflector = new Reflector();
        SimpleFuel = simpleFuel;
        JumpingFuel = 0;

        MaxArmor = Armory = Deflector.CountAsteroids + Resistence.CountAsteroids;
    }

    public override BaseDeflector Deflector { get; init; }
    public override BaseResistances Resistence { get; init; }
    public override BaseSimpleEngines SimpleEngine { get; init; }
    public override BaseJumpingEngines JumpingEnginie { get; init; }
    public override BasePhotonycDeflector PhotonicDeflectors { get; init; }
    public override BaseReflector Reflector { get; init; }
}