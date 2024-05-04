using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class AddresseeGroup : IAddressee
{
    private readonly ICollection<IAddressee> _addressees;

    public AddresseeGroup(ICollection<IAddressee> addressees)
    {
        _addressees = addressees;
    }

    public void AddUser(IAddressee addressee)
    {
        _addressees.Add(addressee);
    }

    public void RemoveUser(IAddressee addressee)
    {
        _addressees.Remove(addressee);
    }

    public void ReceiveMessage(BaseMessage baseMessage)
    {
        foreach (IAddressee addressee in _addressees)
        {
            addressee.ReceiveMessage(baseMessage);
        }
    }
}