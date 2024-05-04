using Itmo.ObjectOrientedProgramming.Lab1.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;

public abstract class BasePhotonycDeflector
{
    public int PhotonDeflections { get; protected set; }

    public void DecreaseDeflections(int count)
    {
        if (count < 0) throw new PositiveArgumentException(nameof(count) + ": Can be only positive");

        PhotonDeflections -= count;
    }
}