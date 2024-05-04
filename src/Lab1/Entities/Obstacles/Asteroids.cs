namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

public class Asteroids : BaseObstacle
{
    public Asteroids(int count) => Count = count;

    public override void CountDamage(double armor) => Damage = armor / Count;
}