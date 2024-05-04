using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Services;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Validators;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class TestsCreatingAssemblies
{
    private Configuration _configuration;
    private Director _director;
    private ValidatorAssembly _validatorAssembly;

    public TestsCreatingAssemblies()
    {
        _configuration = new Configuration(
            "I7-13700K",
            new List<string>() { "Corsair", "Corsair", "Corsair", "Corsair" },
            new List<string>() { "SAMSUNG" },
            "SAMSUNG",
            "RTX 3090",
            "PRIME Z790-P",
            "water",
            "BigBoy",
            new List<string>() { "SAMSUNG", "SAMSUNG" },
            "do");

        _director = new Director(
            Repository.Instance.Cpus,
            Repository.Instance.Gpus,
            Repository.Instance.Hdds,
            Repository.Instance.PowerSupplies,
            Repository.Instance.Rams,
            Repository.Instance.Ssds,
            Repository.Instance.Motherboards,
            Repository.Instance.WiFiAdapters,
            Repository.Instance.PcCases,
            Repository.Instance.CpuCoolingSystems);

        _validatorAssembly = new ValidatorAssembly(new List<IComponentValidator>()
        {
            new CoolingSystemValidator(),
            new CpuValidator(),
            new MotherboardValidator(),
            new RamValidator(),
            new GpuValidator(),
        });
    }

    [Theory]
    [InlineData("I7-13700K")]
    public void TestWithOutComments(string name)
    {
        // Arrange
        _configuration.NameCpu = name;

        // Act
        AssemblyPc assembly = _director.Construct(_configuration, _validatorAssembly);
        var run = new FirstRunAssemblyPc();
        Order order = run.FirstRun(assembly);

        // Assert
        Assert.True(order.Warranty);
        Assert.Equal(assembly, order.AssemblyPc);
        Assert.Equal(0, order.Comments?.Count);
    }

    [Theory]
    [InlineData("I7-13700K")]
    public void TestWithComments(string name)
    {
        // Arrange
        _configuration.NameCpu = name;
        _configuration.NamePowerSupply = "SmallBoy";

        // Act
        AssemblyPc assembly = _director.Construct(_configuration, _validatorAssembly);
        var run = new FirstRunAssemblyPc();
        Order order = run.FirstRun(assembly);

        // Assert
        Assert.True(order.Warranty);
        Assert.Equal(assembly, order.AssemblyPc);
        Assert.Equal(1, order.Comments?.Count);
    }

    [Theory]
    [InlineData("I7-13700K")]
    public void TestWithCommentsWithOutWarranty(string name)
    {
        // Arrange
        _configuration.NameCpu = name;
        _configuration.NamePowerSupply = "SmallBoy";
        _configuration.NameCooling = "air";

        // Act
        AssemblyPc assembly = _director.Construct(_configuration, _validatorAssembly);
        var run = new FirstRunAssemblyPc();
        Order order = run.FirstRun(assembly);

        // Assert
        Assert.False(order.Warranty);
        Assert.Equal(assembly, order.AssemblyPc);
        Assert.Equal(2, order.Comments?.Count);
    }

    [Theory]
    [InlineData("Ryzen 9 5950X")]
    public void TestWithCommentsWithNotCompatibleCpu(string name)
    {
        // Arrange
        _configuration.NameCpu = name;
        _configuration.NamePowerSupply = "SmallBoy";
        _configuration.NameCooling = "air";

        try
        {
            // Act
            AssemblyPc assembly = _director.Construct(_configuration, _validatorAssembly);
            var run = new FirstRunAssemblyPc();
            Order order = run.FirstRun(assembly);
        }
        catch (NotCompatibleComponentsException e)
        {
            // Assert
            Assert.Equal("Cpu is not compatible with motherboard", e.Message);
        }
    }

    [Theory]
    [InlineData("Kingston")]
    public void TestWithCommentsWithNotCompatibleRam(string name)
    {
        // Arrange
        _configuration.NameRam?.Clear();
        _configuration.NameRam?.Add(name);
        _configuration.NameRam?.Add("Kingston");
        _configuration.NamePowerSupply = "SmallBoy";
        _configuration.NameCooling = "air";

        try
        {
            // Act
            AssemblyPc assembly = _director.Construct(_configuration, _validatorAssembly);
            var run = new FirstRunAssemblyPc();
            Order order = run.FirstRun(assembly);
        }
        catch (NotCompatibleComponentsException e)
        {
            // Assert
            Assert.Equal("Ram is not compatible with motherboard", e.Message);
        }
    }

    [Theory]
    [InlineData("RTX 4080")]
    public void TestWithNotCompatibleGpu(string name)
    {
        // Arrange
        _configuration.NameGpu = name;
        _configuration.NameSsd?.Add("SAMSUNG");

        try
        {
            // Act
            AssemblyPc assembly = _director.Construct(_configuration, _validatorAssembly);
            var run = new FirstRunAssemblyPc();
            Order order = run.FirstRun(assembly);
        }
        catch (NotCompatibleComponentsException e)
        {
            // Assert
            Assert.Equal("Gpu is not compatible with motherboard", e.Message);
        }
    }

    [Theory]
    [InlineData("I7-13700K")]
    public void TestWithNotCompatibleMotherboard(string name)
    {
        // Arrange
        _configuration.NameMotherboard = "PRIME Z790";
        _configuration.NameCpu = name;

        try
        {
            // Act
            AssemblyPc assembly = _director.Construct(_configuration, _validatorAssembly);
            var run = new FirstRunAssemblyPc();
            Order order = run.FirstRun(assembly);
        }
        catch (NotCompatibleComponentsException e)
        {
            // Assert
            Assert.Equal("Motherboard is not compatible with WiFi adapter", e.Message);
        }
    }

    [Theory]
    [InlineData("I7-13700K")]
    public void TestWithOutCommentsWithCustomConfig(string name)
    {
        // Arrange
        _configuration.NameCpu = name;

        // Act
        AssemblyPc assembly = _director.Construct(_configuration, _validatorAssembly);
        var run = new FirstRunAssemblyPc();
        Order order = run.FirstRun(assembly);

        Repository.Instance.Cpus.Add(
            new Cpu(
                4500,
                14,
                "LGA1701",
                false,
                5000,
                600,
                500,
                "I9-13700K"));

        if (assembly.Motherboard is null)
            throw new InvalidOperationException("Motherboard is null");

        Motherboard motherboard = assembly.Motherboard.Clone();
        motherboard.Bios = new Bios("UEFI", "6.0.1", new List<string>() { "LGA1701" });
        motherboard.Name = "PRIME Z790-P-6.0.1";
        Repository.Instance.Motherboards.Add(motherboard);

        IBuilder newBuilder = assembly.Direct(new Builder(
            Repository.Instance.Cpus,
            Repository.Instance.Gpus,
            Repository.Instance.Hdds,
            Repository.Instance.PowerSupplies,
            Repository.Instance.Rams,
            Repository.Instance.Ssds,
            Repository.Instance.Motherboards,
            Repository.Instance.WiFiAdapters,
            Repository.Instance.PcCases,
            Repository.Instance.CpuCoolingSystems));
        newBuilder.BuildCpu("I9-13700K");
        newBuilder.BuildMotherboard(motherboard.Name);

        AssemblyPc newAssembly = newBuilder.Build();
        Order newOrder = run.FirstRun(newAssembly);

        // Assert
        Assert.True(order.Warranty);
        Assert.Equal(assembly, order.AssemblyPc);
        Assert.Equal(0, order.Comments?.Count);

        Assert.True(newOrder.Warranty);
        Assert.Equal(newAssembly, newOrder.AssemblyPc);
        Assert.Equal(0, newOrder.Comments?.Count);
        Assert.Equal("6.0.1", newAssembly.Motherboard?.Bios?.Version);
    }
}