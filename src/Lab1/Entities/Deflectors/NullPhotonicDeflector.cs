namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;

public class NullPhotonicDeflector : BasePhotonycDeflector
{
    private const int PhotonDeflectionsAmount = 0;

    public NullPhotonicDeflector()
    {
        PhotonDeflections = PhotonDeflectionsAmount;
    }
}