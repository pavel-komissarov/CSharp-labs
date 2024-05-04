using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public class CheckShipOnResult
    : ICheckShipOnResult
{
    public bool IsLost(BaseShip? ship)
    {
        if (ship is null) throw new ArgumentNullException(nameof(ship));

        return ship.JumpingFuel < 0;
    }

    public bool IsCrash(BaseShip? ship)
    {
        if (ship is null) throw new ArgumentNullException(nameof(ship));

        return ship.Armory < 0;
    }

    public bool IsSuccess(BaseShip? ship)
    {
        if (ship is null) throw new ArgumentNullException(nameof(ship));

        return !(IsCrash(ship) || IsLost(ship) || IsDie(ship)) && ship.SimpleFuel >= 0;
    }

    public bool IsDie(BaseShip? ship)
    {
        if (ship is null) throw new ArgumentNullException(nameof(ship));

        return ship.PhotonicDeflectors.PhotonDeflections < 0;
    }
}