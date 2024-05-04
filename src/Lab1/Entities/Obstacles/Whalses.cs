namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

public class Whalses : BaseObstacle
{
    public Whalses(int count) => Count = count;

    public override void CountDamage(double armor) => Damage = armor;
}