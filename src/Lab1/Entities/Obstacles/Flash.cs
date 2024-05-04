namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

public class Flash : BaseObstacle
{
    private const int ArmorCoefficient = 0;

    public Flash(int count) => Count = count;

    public override void CountDamage(double armor) => Damage = ArmorCoefficient * armor;
}