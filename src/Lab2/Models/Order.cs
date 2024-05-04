using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class Order
{
    public Order(AssemblyPc assemblyPc, ICollection<string>? comments, bool warranty)
    {
        AssemblyPc = assemblyPc;
        Comments = comments;
        Warranty = warranty;
    }

    public AssemblyPc AssemblyPc { get; set; }
    public ICollection<string>? Comments { get; }
    public bool Warranty { get; set; }
}