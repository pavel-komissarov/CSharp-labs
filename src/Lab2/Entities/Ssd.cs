using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Ssd : BaseComponent, IClonable<Ssd>
{
    public Ssd(
        string? connectionType,
        int capacity,
        int maxSpeed,
        int powerConsumption,
        string name)
    {
        ConnectionType = connectionType ?? throw new ArgumentNullException(nameof(connectionType));
        Capacity = capacity > 0 ? capacity : throw new ArgumentException("Capacity must be positive");
        MaxSpeed = maxSpeed > 0 ? maxSpeed : throw new ArgumentException("Max speed must be positive");
        PowerConsumption = powerConsumption > 0
            ? powerConsumption
            : throw new ArgumentException("Power consumption must be positive");
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }

    public string? ConnectionType { get; set; }
    public int Capacity { get; set; }
    public int MaxSpeed { get; set; }
    public int PowerConsumption { get; set; }
    public override string Name { get; set; }

    public Ssd Clone()
    {
        return new Ssd(
            ConnectionType,
            Capacity,
            MaxSpeed,
            PowerConsumption,
            Name);
    }
}