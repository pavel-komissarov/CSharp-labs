using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public interface IBuilder
{
    AssemblyPc Build();

    void BuildCpu(string? name);

    void BuildGpu(string? name);

    void BuildHdd(ICollection<string>? names);

    void BuildMotherboard(string? name);

    void BuildPowerSupply(string? name);

    void BuildRam(ICollection<string>? names);

    void BuildSsd(ICollection<string>? names);

    void BuildWiFiAdapter(string? name);

    void BuildCase(string? name);

    void BuildCoolingSystem(string? name);
}