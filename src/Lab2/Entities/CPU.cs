using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Cpu : BaseComponent, IClonable<Cpu>
{
    public Cpu(
        int frequency,
        int cores,
        string? socket,
        bool videoCore,
        int memoryFrequency,
        int tdp,
        int powerConsumption,
        string? name)
    {
        Frequency = frequency <= 0
            ? throw new ArgumentException("Argument must be positive", nameof(frequency))
            : frequency;
        Cores = cores <= 0 ? throw new ArgumentException("Argument must be positive", nameof(cores)) : cores;
        Socket = socket ?? throw new ArgumentNullException(nameof(socket));
        VideoCore = videoCore;
        MemoryFrequency = memoryFrequency <= 0
            ? throw new ArgumentException("Argument must be positive", nameof(memoryFrequency))
            : memoryFrequency;
        Tdp = tdp <= 0 ? throw new ArgumentException("Argument must be positive", nameof(tdp)) : tdp;
        PowerConsumption = powerConsumption <= 0
            ? throw new ArgumentException("Argument must be positive", nameof(powerConsumption))
            : powerConsumption;
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }

    public int Frequency { get; set; }
    public int Cores { get; set; }
    public string? Socket { get; set; }
    public bool VideoCore { get; set; }
    public int MemoryFrequency { get; set; }
    public int Tdp { get; set; }
    public int PowerConsumption { get; set; }
    public override string Name { get; set; }

    public Cpu Clone()
    {
        return new Cpu(Frequency, Cores, Socket, VideoCore, MemoryFrequency, Tdp, PowerConsumption, Name);
    }
}