namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;

public class PhotonicDeflector : BasePhotonycDeflector
{
    private const int PhotonDeflectionsAmount = 3;

    public PhotonicDeflector()
    {
        PhotonDeflections = PhotonDeflectionsAmount;
    }
}