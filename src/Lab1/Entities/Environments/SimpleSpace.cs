using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;

public class SimpleSpace : BaseInvironments
{
    public SimpleSpace(int distance, BaseObstacle obstacle)
    : base(distance)
    {
        if (obstacle is not Meteorites && obstacle is not Asteroids)
        {
            throw new ArgumentException("The argument can be only Meteorites or Asteroids", nameof(obstacle));
        }

        Obstacle = obstacle ??
                   throw new ArgumentException("The argument must be initialized and passed", nameof(obstacle));
    }

    public override BaseObstacle Obstacle { get; init; }

    public override void Fly(BaseShip ship)
    {
        if (ship == null)
        {
            throw new ArgumentException("Argument must be", nameof(ship));
        }

        Obstacle.CountDamage(ship.Armory);

        ship.CountTimeSimpleFuel(Distance);

        if (Obstacle.Count > 0)
        {
            ship.TakeDamage(Obstacle.Damage, Obstacle.Count);
        }
    }
}