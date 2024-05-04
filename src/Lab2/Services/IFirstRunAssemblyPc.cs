using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public interface IFirstRunAssemblyPc
{
    Order FirstRun(AssemblyPc assemblyPc);
}