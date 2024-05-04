using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class Director : IDirector
{
    private readonly IBuilder _builder;

    public Director(
        ICollection<Cpu> repositoryCpu,
        ICollection<Gpu> repositoryGpu,
        ICollection<Hdd> repositoryHdd,
        ICollection<PowerSupply> repositoryPowerSupply,
        ICollection<Ram> repositoryRam,
        ICollection<Ssd> repositorySsd,
        ICollection<Motherboard> repositoryMotherboard,
        ICollection<WiFiAdapter> repositoryWiFiAdapter,
        ICollection<PcCase> repositoryPcCase,
        ICollection<CpuCoolingSystem> repositoryCpuCoolingSystem)
    {
        _builder = new Builder(
            repositoryCpu,
            repositoryGpu,
            repositoryHdd,
            repositoryPowerSupply,
            repositoryRam,
            repositorySsd,
            repositoryMotherboard,
            repositoryWiFiAdapter,
            repositoryPcCase,
            repositoryCpuCoolingSystem);
    }

    public AssemblyPc Construct(Configuration configuration, ValidatorAssembly validatorAssembly)
    {
        if (configuration is null) throw new ArgumentNullException(nameof(configuration));
        if (validatorAssembly is null) throw new ArgumentNullException(nameof(validatorAssembly));

        _builder.BuildCpu(configuration.NameCpu);
        _builder.BuildGpu(configuration.NameGpu);
        _builder.BuildHdd(configuration.NameHdd);
        _builder.BuildMotherboard(configuration.NameMotherboard);
        _builder.BuildPowerSupply(configuration.NamePowerSupply);
        _builder.BuildRam(configuration.NameRam);
        _builder.BuildSsd(configuration.NameSsd);
        _builder.BuildWiFiAdapter(configuration.NameWifi);
        _builder.BuildCase(configuration.NameCase);
        _builder.BuildCoolingSystem(configuration.NameCooling);

        AssemblyPc betaAssembly = validatorAssembly.Valid(_builder.Build());

        return betaAssembly;
    }
}