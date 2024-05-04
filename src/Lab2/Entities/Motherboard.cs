using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Motherboard : BaseComponent, IClonable<Motherboard>
{
    public Motherboard(
        string? cpuSocket,
        int numberOfPcieLines,
        int numberOfSataPorts,
        Chipset? chipset,
        int ddrStandard,
        int numberOfRamSlots,
        string? formFactor,
        Bios? bios,
        string? name,
        bool wiFi)
    {
        CpuSocket = cpuSocket ?? throw new ArgumentNullException(nameof(cpuSocket));
        NumberOfPcieLines = numberOfPcieLines <= 0
            ? throw new ArgumentException("Argument must be positive", nameof(numberOfPcieLines))
            : numberOfPcieLines;
        NumberOfSataPorts = numberOfSataPorts <= 0
            ? throw new ArgumentException("Argument must be positive", nameof(numberOfSataPorts))
            : numberOfSataPorts;
        Chipset = chipset ?? throw new ArgumentNullException(nameof(chipset));
        DdrStandard = ddrStandard <= 0
            ? throw new ArgumentException("Argument must be positive", nameof(ddrStandard))
            : ddrStandard;
        NumberOfRamSlots = numberOfRamSlots <= 0
            ? throw new ArgumentException("Argument must be positive", nameof(numberOfRamSlots))
            : numberOfRamSlots;
        FormFactor = formFactor;
        Bios = bios ?? throw new ArgumentNullException(nameof(bios));
        Name = name ?? throw new ArgumentNullException(nameof(name));
        WiFi = wiFi;
    }

    public string? CpuSocket { get; set; }
    public int NumberOfPcieLines { get; set; }
    public int NumberOfSataPorts { get; set; }
    public Chipset? Chipset { get; set; }
    public int DdrStandard { get; set; }
    public int NumberOfRamSlots { get; set; }
    public string? FormFactor { get; set; }
    public Bios? Bios { get; set; }
    public override string Name { get; set; }
    public bool WiFi { get; set; }

    public Motherboard Clone()
    {
        return new Motherboard(
            CpuSocket,
            NumberOfPcieLines,
            NumberOfSataPorts,
            Chipset,
            DdrStandard,
            NumberOfRamSlots,
            FormFactor,
            Bios,
            Name,
            WiFi);
    }
}