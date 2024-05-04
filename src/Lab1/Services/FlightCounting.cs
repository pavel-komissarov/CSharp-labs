using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

// thanks )
public class FlightCounting
    : IFlightCounting
{
    private const int CoefficientForJumpingFuel = 2;

    public IEnumerable<BaseShip> FlyAnalizes(
        IEnumerable<BaseShip> ships,
        IEnumerable<BaseInvironments> invironments)
    {
        if (ships is null)
        {
            throw new ArgumentNullException(nameof(ships));
        }

        if (invironments is null)
        {
            throw new ArgumentNullException(nameof(invironments));
        }

        IEnumerable<BaseShip> shipsList = ships.ToList();
        IEnumerable<BaseInvironments> invironmentsList = invironments.ToList();

        var query = from ship in shipsList
            from invironment in invironmentsList
            where new CheckShipOnResult().IsSuccess(ship)
            select new { Ship = ship, Environment = invironment };

        foreach (var pair in query)
        {
            pair.Environment.Fly(pair.Ship);
        }

        var sortedShip = shipsList.OrderByDescending(ship =>
                ((ship.JumpingFuel * CoefficientForJumpingFuel) + ship.SimpleFuel) / ship.Time)
            .ThenBy(ship => new CheckShipOnResult().IsSuccess(ship))
            .ToList();

        return sortedShip;
    }

    public SuccessResultFly? BestShip(IEnumerable<BaseShip> ships, IEnumerable<BaseInvironments> environments)
    {
        var analysisResult = FlyAnalizes(ships, environments).ToList();

        return new CheckShipOnResult().IsSuccess(analysisResult[0]) ? new SuccessResultFly(analysisResult[0]) : null;
    }
}