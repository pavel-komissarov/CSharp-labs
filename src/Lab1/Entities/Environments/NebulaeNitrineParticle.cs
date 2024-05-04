using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Resistances;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;

public class NebulaeNitrineParticle : BaseInvironments
{
    public NebulaeNitrineParticle(int distance, Whalses whalse)
        : base(distance)
    {
        Obstacle = whalse ?? throw new ArgumentException("Argument must be", nameof(whalse));
    }

    public override BaseObstacle Obstacle { get; init; }

    public override void Fly(BaseShip ship)
    {
        if (ship == null)
        {
            throw new ArgumentException("Argument must be", nameof(ship));
        }

        Obstacle.CountDamage(ship.MaxArmor);

        if (ship.SimpleEngine is EngineE)
        {
            ship.CountTimeSimpleFuel(Distance);

            if (ship.Reflector is Reflector && Obstacle.Count - 1 > 0)
            {
                ship.TakeDamage(Obstacle.Damage, Obstacle.Count - 1);
                ship.Reflector.UseReflector();
            }
            else
            {
                ship.TakeDamage(Obstacle.Damage, Obstacle.Count);
            }
        }
        else
        {
            ship.CountTimeSimpleFuel(Distance, 3);

            if (ship.Reflector is Reflector && Obstacle.Count - 1 > 0)
            {
                ship.TakeDamage(Obstacle.Damage, Obstacle.Count - 1);
                ship.Reflector.UseReflector();
            }
            else
            {
                ship.TakeDamage(Obstacle.Damage, Obstacle.Count);
            }
        }
    }
}