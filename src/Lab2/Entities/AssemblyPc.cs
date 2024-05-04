using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class AssemblyPc
{
    public AssemblyPc(
        Gpu? gpu,
        Cpu? cpu,
        ICollection<Hdd>? hdd,
        Motherboard? motherboard,
        PowerSupply? powerSupply,
        ICollection<Ram>? ram,
        ICollection<Ssd>? ssd,
        WiFiAdapter? wiFiAdapter,
        PcCase? pcCase,
        CpuCoolingSystem? coolingSystem)
    {
        if (hdd is null && ssd is null) throw new ArgumentException("At least one storage device must be specified");

        Gpu = gpu ?? throw new System.ArgumentNullException(nameof(gpu));
        Cpu = cpu ?? throw new System.ArgumentNullException(nameof(cpu));
        Hdd = hdd ?? new List<Hdd>();
        Motherboard = motherboard ?? throw new System.ArgumentNullException(nameof(motherboard));
        PowerSupply = powerSupply ?? throw new System.ArgumentNullException(nameof(powerSupply));
        Ram = ram ?? throw new System.ArgumentNullException(nameof(ram));
        Ssd = ssd ?? new List<Ssd>();
        WiFiAdapter = wiFiAdapter;
        PcCase = pcCase;
        CoolingSystem = coolingSystem;
    }

    public Gpu? Gpu { get; init; }
    public Cpu? Cpu { get; init; }
    public ICollection<Hdd>? Hdd { get; init; }
    public Motherboard? Motherboard { get; init; }
    public PowerSupply? PowerSupply { get; init; }
    public ICollection<Ram>? Ram { get; init; }
    public ICollection<Ssd>? Ssd { get; init; }
    public WiFiAdapter? WiFiAdapter { get; init; }
    public PcCase? PcCase { get; init; }
    public CpuCoolingSystem? CoolingSystem { get; init; }

    public IBuilder Direct(IBuilder builder)
    {
        builder = builder ?? throw new ArgumentNullException(nameof(builder));

        builder.BuildCpu(Cpu?.Name);
        builder.BuildGpu(Gpu?.Name);
        builder.BuildMotherboard(Motherboard?.Name);
        builder.BuildPowerSupply(PowerSupply?.Name);
        builder.BuildRam(Ram?.Select(ram => ram.Name).ToList());
        builder.BuildHdd(Hdd?.Select(hdd => hdd.Name).ToList());
        builder.BuildSsd(Ssd?.Select(ssd => ssd.Name).ToList());
        builder.BuildWiFiAdapter(WiFiAdapter?.Name);
        builder.BuildCase(PcCase?.Name);

        return builder;
    }
}