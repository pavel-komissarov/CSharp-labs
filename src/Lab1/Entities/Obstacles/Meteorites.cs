namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

public class Meteorites : BaseObstacle
{
    public Meteorites(int count) => Count = count;

    public override void CountDamage(double armor) => Damage = armor / Count;
}