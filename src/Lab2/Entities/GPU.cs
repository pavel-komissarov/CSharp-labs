using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Gpu : BaseComponent, IClonable<Gpu>
{
    public Gpu(
        int height,
        int lenght,
        int videoMemory,
        int pcieVersion,
        int frequency,
        int powerConsumption,
        string? name)
    {
        Height = height > 0 ? height : throw new ArgumentException("Argument must be positive", nameof(height));
        Lenght = lenght > 0 ? lenght : throw new ArgumentException("Argument must be positive", nameof(lenght));
        VideoMemory = videoMemory > 0
            ? videoMemory
            : throw new ArgumentException("Argument must be positive", nameof(videoMemory));
        PcieVersion = pcieVersion > 0
            ? pcieVersion
            : throw new ArgumentException("Argument must be positive", nameof(pcieVersion));
        Frequency = frequency > 0
            ? frequency
            : throw new ArgumentException("Argument must be positive", nameof(frequency));
        PowerConsumption = powerConsumption > 0
            ? powerConsumption
            : throw new ArgumentException("Argument must be positive", nameof(powerConsumption));
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }

    public int Height { get; set; }
    public int Lenght { get; set; }
    public int VideoMemory { get; set; }
    public int PcieVersion { get; set; }
    public int Frequency { get; set; }
    public int PowerConsumption { get; set; }
    public override string Name { get; set; }

    public Gpu Clone()
    {
        return new Gpu(Height, Lenght, VideoMemory, PcieVersion, Frequency, PowerConsumption, Name);
    }
}