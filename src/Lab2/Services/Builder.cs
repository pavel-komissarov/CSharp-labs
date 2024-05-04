using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Factories;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class Builder : IBuilder
{
    private readonly ComputerComponentsFactory _computerComponentsFactory = new ComputerComponentsFactory(
        new FactoryCpu(),
        new FactoryGpu(),
        new FactoryHdd(),
        new FactoryPowerSupply(),
        new FactoryRam(),
        new FactorySsd(),
        new FactoryMotherboard(),
        new FactoryWiFiAdapter(),
        new FactoryCase(),
        new FactoryCoolingSystem());

    private Cpu? _cpu;
    private Gpu? _gpu;
    private ICollection<Hdd>? _hdd;
    private Motherboard? _motherboard;
    private PowerSupply? _powerSupply;
    private ICollection<Ram>? _ram;
    private ICollection<Ssd>? _ssd;
    private WiFiAdapter? _wiFiAdapter;
    private PcCase? _pcCase;
    private CpuCoolingSystem? _coolingSystem;
    private ICollection<Cpu> _repositoryCpu;
    private ICollection<Gpu> _repositoryGpu;
    private ICollection<Hdd> _repositoryHdd;
    private ICollection<PowerSupply> _repositoryPowerSupply;
    private ICollection<Ram> _repositoryRam;
    private ICollection<Ssd> _repositorySsd;
    private ICollection<Motherboard> _repositoryMotherboard;
    private ICollection<WiFiAdapter> _repositoryWiFiAdapter;
    private ICollection<PcCase> _repositoryPcCase;
    private ICollection<CpuCoolingSystem> _repositoryCpuCoolingSystem;

    public Builder(
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
        _repositoryCpu = repositoryCpu;
        _repositoryGpu = repositoryGpu;
        _repositoryHdd = repositoryHdd;
        _repositoryPowerSupply = repositoryPowerSupply;
        _repositoryRam = repositoryRam;
        _repositorySsd = repositorySsd;
        _repositoryMotherboard = repositoryMotherboard;
        _repositoryWiFiAdapter = repositoryWiFiAdapter;
        _repositoryPcCase = repositoryPcCase;
        _repositoryCpuCoolingSystem = repositoryCpuCoolingSystem;
    }

    public AssemblyPc Build()
    {
        return new AssemblyPc(
            _gpu,
            _cpu,
            _hdd,
            _motherboard,
            _powerSupply,
            _ram,
            _ssd,
            _wiFiAdapter,
            _pcCase,
            _coolingSystem);
    }

    public void BuildCpu(string? name)
    {
        _cpu = _computerComponentsFactory.CreateCpu(name, _repositoryCpu);
    }

    public void BuildGpu(string? name)
    {
        _gpu = _computerComponentsFactory.CreateGpu(name, _repositoryGpu);
    }

    public void BuildHdd(ICollection<string>? names)
    {
        _hdd = new List<Hdd>();

        _hdd = (names ?? throw new ArgumentNullException(nameof(names)))
            .Select(name => _computerComponentsFactory.CreateHdd(name, _repositoryHdd)).ToList();
    }

    public void BuildMotherboard(string? name)
    {
        _motherboard = _computerComponentsFactory.CreateMotherboard(name, _repositoryMotherboard);
    }

    public void BuildPowerSupply(string? name)
    {
        _powerSupply = _computerComponentsFactory.CreatePowerSupply(name, _repositoryPowerSupply);
    }

    public void BuildRam(ICollection<string>? names)
    {
        _ram = new List<Ram>();

        _ram = (names ?? throw new ArgumentNullException(nameof(names)))
            .Select(name => _computerComponentsFactory.CreateRam(name, _repositoryRam)).ToList();
    }

    public void BuildSsd(ICollection<string>? names)
    {
        _ssd = new List<Ssd>();

        _ssd = (names ?? throw new ArgumentNullException(nameof(names)))
            .Select(name => _computerComponentsFactory.CreateSsd(name, _repositorySsd)).ToList();
    }

    public void BuildWiFiAdapter(string? name)
    {
        _wiFiAdapter =
            _computerComponentsFactory.CreateWiFiAdapter(name, _repositoryWiFiAdapter);
    }

    public void BuildCase(string? name)
    {
        _pcCase = _computerComponentsFactory.CreatePcCase(name, _repositoryPcCase);
    }

    public void BuildCoolingSystem(string? name)
    {
        _coolingSystem = _computerComponentsFactory.CreateCpuCoolingSystem(name, _repositoryCpuCoolingSystem);
    }
}