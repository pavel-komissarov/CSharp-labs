using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class Configuration
{
    public Configuration(
        string nameCpu,
        ICollection<string> nameRam,
        ICollection<string> nameHdd,
        string nameCase,
        string nameGpu,
        string nameMotherboard,
        string nameCooling,
        string namePowerSupply,
        ICollection<string> nameSsd,
        string? nameWifi)
    {
        NameCpu = nameCpu;
        NameRam = nameRam;
        NameHdd = nameHdd;
        NameCase = nameCase;
        NameGpu = nameGpu;
        NameMotherboard = nameMotherboard;
        NameCooling = nameCooling;
        NamePowerSupply = namePowerSupply;
        NameSsd = nameSsd;
        NameWifi = nameWifi;
    }

    public string? NameCpu { get; set; }
    public ICollection<string>? NameRam { get; init; }
    public ICollection<string>? NameHdd { get; init; }
    public string? NameCase { get; set; }
    public string? NameGpu { get; set; }
    public string? NameMotherboard { get; set; }
    public string? NameCooling { get; set; }
    public string? NamePowerSupply { get; set; }
    public ICollection<string>? NameSsd { get; init; }
    public string? NameWifi { get; set; }
}