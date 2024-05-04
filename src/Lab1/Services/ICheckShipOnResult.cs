using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public interface ICheckShipOnResult
{
    public abstract bool IsDie(BaseShip? ship);

    public abstract bool IsLost(BaseShip? ship);

    public abstract bool IsCrash(BaseShip? ship);

    public abstract bool IsSuccess(BaseShip? ship);
}