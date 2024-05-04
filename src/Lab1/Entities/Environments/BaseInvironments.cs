using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;

public abstract class BaseInvironments
{
    private readonly int _distance;

    protected BaseInvironments(int distance)
    {
        if (distance < 0) throw new PositiveArgumentException(nameof(distance) + ": Can be only positive");

        _distance = distance;
    }

    public abstract BaseObstacle Obstacle { get; init; }

    public int Distance
    {
        get => _distance;
    }

    public abstract void Fly(BaseShip ship);
}