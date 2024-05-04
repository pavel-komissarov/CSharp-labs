using System;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class PcCase : BaseComponent, IClonable<PcCase>
{
    public PcCase(
        int maxVideoCardLength,
        int maxVideoCardWidth,
        ICollection<string>? supportedMotherboardFormFactors,
        int heightInInches,
        int widthInInches,
        string name)
    {
        MaxVideoCardHeight = maxVideoCardLength > 0
            ? maxVideoCardLength
            : throw new ArgumentException("Argument must be positive", nameof(maxVideoCardLength));
        MaxVideoCardWidth = maxVideoCardWidth > 0
            ? maxVideoCardWidth
            : throw new ArgumentException("Argument must be positive", nameof(maxVideoCardWidth));
        SupportedFormFactors = supportedMotherboardFormFactors ??
                               throw new ArgumentNullException(nameof(supportedMotherboardFormFactors));
        HeightInInches = heightInInches > 0
            ? heightInInches
            : throw new ArgumentException("Argument must be positive", nameof(heightInInches));
        WidthInInches = widthInInches > 0
            ? widthInInches
            : throw new ArgumentException("Argument must be positive", nameof(widthInInches));
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }

    public int MaxVideoCardHeight { get; set; }
    public int MaxVideoCardWidth { get; set; }
    public ICollection<string>? SupportedFormFactors { get; }
    public int HeightInInches { get; set; }
    public int WidthInInches { get; set; }
    public override string Name { get; set; }

    public PcCase Clone()
    {
        return new PcCase(
            MaxVideoCardHeight,
            MaxVideoCardWidth,
            SupportedFormFactors,
            HeightInInches,
            WidthInInches,
            Name);
    }
}