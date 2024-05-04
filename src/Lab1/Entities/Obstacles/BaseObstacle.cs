namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

public abstract class BaseObstacle
{
    public double Damage { get; protected set; }
    public int Count { get; init; }

    public abstract void CountDamage(double armor);
}