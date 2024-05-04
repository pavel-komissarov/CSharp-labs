using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;

public class NebulaeHighDensity : BaseInvironments
{
    public NebulaeHighDensity(int distance, Flash flash)
        : base(distance)
    {
        Obstacle = flash ?? throw new ArgumentException("The argument must be initialized and passed", nameof(flash));
    }

    public override BaseObstacle Obstacle { get; init; }

    public override void Fly(BaseShip ship)
    {
        if (ship == null)
        {
            throw new ArgumentException("The argument must be initialized and passed", nameof(ship));
        }

        Obstacle.CountDamage(ship.MaxArmor);

        if (ship.JumpingFuel >= 0)
        {
            ship.CountTimeJumpingFuel(Distance);

            if (Obstacle.Count > 0)
            {
                ship.PhotonicDeflectors.DecreaseDeflections(Obstacle.Count);
            }
        }
    }
}