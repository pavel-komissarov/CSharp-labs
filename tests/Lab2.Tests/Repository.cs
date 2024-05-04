using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

// In essence, this is a class with test data and is in no way connected with business logic.
// Just for the convenience of accessing collections of components.
public sealed class Repository
{
    private static readonly object _lock = new();
    private static Repository? _instance;
    private Repository() { }

    public static Repository Instance
    {
        get
        {
            if (_instance is not null)
                return _instance;
            lock (_lock)
            {
                return _instance = new Repository();
            }
        }
    }

    public ICollection<PcCase> PcCases { get; } = new List<PcCase>()
    {
        new PcCase(
            500,
            2000,
            new List<string>() { "ATX" },
            5000,
            4000,
            "SAMSUNG"),
        new PcCase(
            300,
            1000,
            new List<string>() { "ATX", "Mini-ATX" },
            3000,
            2000,
            "KINGSTON"),
    };

    public ICollection<CpuCoolingSystem> CpuCoolingSystems { get; } = new List<CpuCoolingSystem>()
    {
        new CpuCoolingSystem(
            30,
            new List<string>() { "LGA1700", "AM5" },
            600,
            "water"),
        new CpuCoolingSystem(
            20,
            new List<string>() { "LGA1700", "AM5" },
            300,
            "air"),
    };

    public ICollection<Cpu> Cpus { get; } = new List<Cpu>()
    {
        new Cpu(
            4500,
            14,
            "LGA1700",
            false,
            5000,
            600,
            500,
            "I7-13700K"),
        new Cpu(
            300,
            24,
            "AM5",
            true,
            4000,
            450,
            300,
            "Ryzen 9 5950X"),
    };

    public ICollection<Ram> Rams { get; } = new List<Ram>()
    {
        new Ram(
            16,
            new List<JedecFrequencyVoltagePair>()
            {
                new JedecFrequencyVoltagePair(5000, 10),
                new JedecFrequencyVoltagePair(5500, 20),
            },
            new List<Xmp>()
            {
                new Xmp(new List<int>() { 17, 18, 19, 20 }, 30, 5000),
                new Xmp(new List<int>() { 20, 22, 23, 24 }, 32, 5500),
            },
            "DIMM",
            5,
            200,
            "Corsair"),
        new Ram(
            8,
            new List<JedecFrequencyVoltagePair>()
            {
                new JedecFrequencyVoltagePair(4000, 10),
                new JedecFrequencyVoltagePair(4500, 20),
            },
            null,
            "DIMM",
            4,
            150,
            "Kingston"),
    };

    public ICollection<Gpu> Gpus { get; } = new List<Gpu>()
    {
        new Gpu(
            1400,
            400,
            16,
            4,
            5000,
            1000,
            "RTX 3090"),
        new Gpu(
            3000,
            2000,
            8,
            3,
            4000,
            800,
            "RTX 4080"),
    };

    public ICollection<Hdd> Hdds { get; } = new List<Hdd>()
    {
        new Hdd(
            1000,
            1000,
            150,
            "SAMSUNG"),
        new Hdd(
            1000,
            500,
            100,
            "KINGSTON"),
    };

    public ICollection<Motherboard> Motherboards { get; } = new List<Motherboard>()
    {
        new Motherboard(
            "LGA1700",
            3,
            4,
            new Chipset(5500, new List<Xmp>()
            {
                new Xmp(new List<int>() { 17, 18, 19, 20 }, 30, 4000),
                new Xmp(new List<int>() { 20, 22, 23, 24 }, 30, 3000),
            }),
            5,
            4,
            "ATX",
            new Bios("EFFI", "1.0", new List<string>() { "I7-13700K" }),
            "PRIME Z790-P",
            true),
        new Motherboard(
            "AM5",
            1,
            4,
            new Chipset(4500, null),
            4,
            4,
            "Mini-ATX",
            new Bios("EFFI", "1.0", new List<string>() { "Ryzen 9 5950X" }),
            "ROG STRIX B550-F GAMING",
            false),
        new Motherboard(
            "LGA1700",
            3,
            4,
            new Chipset(5500, new List<Xmp>()
            {
                new Xmp(new List<int>() { 17, 18, 19, 20 }, 30, 4000),
                new Xmp(new List<int>() { 20, 22, 23, 24 }, 30, 3000),
            }),
            5,
            4,
            "ATX",
            new Bios("EFFI", "1.0", new List<string>() { "I7-13700K" }),
            "PRIME Z790",
            false),
    };

    public ICollection<PowerSupply> PowerSupplies { get; } = new List<PowerSupply>()
    {
        new PowerSupply(5000, "BigBoy"),
        new PowerSupply(2400, "SmallBoy"),
    };

    public ICollection<Ssd> Ssds { get; } = new List<Ssd>()
    {
        new Ssd(
            "PCIE",
            1000,
            1000,
            20,
            "SAMSUNG"),
        new Ssd(
            "SATA",
            500,
            500,
            10,
            "KINGSTON"),
    };

    public ICollection<WiFiAdapter> WiFiAdapters { get; } = new List<WiFiAdapter>()
    {
        new WiFiAdapter(
            4,
            false,
            4,
            50,
            "just"),
        new WiFiAdapter(
            5,
            true,
            5,
            100,
            "do"),
    };
}