using System.Data;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public class SuccessResultFly
{
    public SuccessResultFly(BaseShip ship)
    {
        Ship = ship ?? throw new NoNullAllowedException(nameof(ship));
        Time = ship.Time;
        Fuel = ship.SimpleFuel;
    }

    public BaseShip Ship { get; init; }
    public double Fuel { get; init; }
    public double Time { get; init; }
}