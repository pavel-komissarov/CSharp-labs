using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Factories;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class ComputerComponentsFactory
{
    private readonly Factory<Cpu> _cpuFactory;
    private readonly Factory<Gpu> _gpuFactory;
    private readonly Factory<Hdd> _hddFactory;
    private readonly Factory<PowerSupply> _powerSupplyFactory;
    private readonly Factory<Ram> _ramFactory;
    private readonly Factory<Ssd> _ssdFactory;
    private readonly Factory<Motherboard> _motherboardFactory;
    private readonly Factory<WiFiAdapter> _wiFiAdapterFactory;
    private readonly Factory<PcCase> _pcCaseFactory;
    private readonly Factory<CpuCoolingSystem> _cpuCoolingSystemFactory;

    public ComputerComponentsFactory(
        Factory<Cpu> cpuFactory,
        Factory<Gpu> gpuFactory,
        Factory<Hdd> hddFactory,
        Factory<PowerSupply> powerSupplyFactory,
        Factory<Ram> ramFactory,
        Factory<Ssd> ssdFactory,
        Factory<Motherboard> motherboardFactory,
        Factory<WiFiAdapter> wiFiAdapterFactory,
        Factory<PcCase> pcCaseFactory,
        Factory<CpuCoolingSystem> cpuCoolingSystemFactory)
    {
        _cpuFactory = cpuFactory;
        _gpuFactory = gpuFactory;
        _hddFactory = hddFactory;
        _powerSupplyFactory = powerSupplyFactory;
        _ramFactory = ramFactory;
        _ssdFactory = ssdFactory;
        _motherboardFactory = motherboardFactory;
        _wiFiAdapterFactory = wiFiAdapterFactory;
        _pcCaseFactory = pcCaseFactory;
        _cpuCoolingSystemFactory = cpuCoolingSystemFactory;
    }

    public Cpu CreateCpu(string? name, ICollection<Cpu> repositoryComponents)
    {
        return _cpuFactory.CreateByName(name, repositoryComponents);
    }

    public Gpu CreateGpu(string? name, ICollection<Gpu> repositoryComponents)
    {
        return _gpuFactory.CreateByName(name, repositoryComponents);
    }

    public Hdd CreateHdd(string? name, ICollection<Hdd> repositoryComponents)
    {
        return _hddFactory.CreateByName(name, repositoryComponents);
    }

    public PowerSupply CreatePowerSupply(string? name, ICollection<PowerSupply> repositoryComponents)
    {
        return _powerSupplyFactory.CreateByName(name, repositoryComponents);
    }

    public Ram CreateRam(string? name, ICollection<Ram> repositoryComponents)
    {
        return _ramFactory.CreateByName(name, repositoryComponents);
    }

    public Ssd CreateSsd(string? name, ICollection<Ssd> repositoryComponents)
    {
        return _ssdFactory.CreateByName(name, repositoryComponents);
    }

    public Motherboard CreateMotherboard(string? name, ICollection<Motherboard> repositoryComponents)
    {
        return _motherboardFactory.CreateByName(name, repositoryComponents);
    }

    public WiFiAdapter CreateWiFiAdapter(string? name, ICollection<WiFiAdapter> repositoryComponents)
    {
        return _wiFiAdapterFactory.CreateByName(name, repositoryComponents);
    }

    public PcCase CreatePcCase(string? name, ICollection<PcCase> repositoryComponents)
    {
        return _pcCaseFactory.CreateByName(name, repositoryComponents);
    }

    public CpuCoolingSystem CreateCpuCoolingSystem(string? name, ICollection<CpuCoolingSystem> repositoryComponents)
    {
        return _cpuCoolingSystemFactory.CreateByName(name, repositoryComponents);
    }
}