using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public interface IFlightCounting
{
    public abstract IEnumerable<BaseShip> FlyAnalizes(
        IEnumerable<BaseShip> ships,
        IEnumerable<BaseInvironments> invironments);

    public abstract SuccessResultFly? BestShip(
        IEnumerable<BaseShip> ships,
        IEnumerable<BaseInvironments> environments);
}