using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class FirstRunAssemblyPc : IFirstRunAssemblyPc
{
    public Order FirstRun(AssemblyPc assemblyPc)
    {
        if (assemblyPc is null)
            throw new ArgumentNullException(nameof(assemblyPc));

        List<string> comments = new();
        bool warranty = true;

        if (!new CheckRam().Check(assemblyPc))
            throw new InvalidOperationException("Frequency of RAM is less than frequency of CPU");

        CheckWattsResult checkWattsResult = new CheckWatts().Check(assemblyPc);

        if (!checkWattsResult.Result)
        {
            if (checkWattsResult.Diff <= 200)
            {
                comments.Add("Power supply is not enough for this configuration, but it is not critical");
            }
            else
            {
                comments.Add("Power supply is not enough for this configuration");
                warranty = false;
            }
        }

        if (assemblyPc.CoolingSystem is not null
            && assemblyPc.Cpu != null
            && assemblyPc.CoolingSystem.Tdp < assemblyPc.Cpu.Tdp)
        {
            comments.Add("Cooling system is not enough for this CPU");
            warranty = false;
        }

        return new Order(assemblyPc, comments, warranty);
    }
}