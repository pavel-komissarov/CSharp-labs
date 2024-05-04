using System;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class AddresseeWithFilter : IAddressee
{
    private readonly IAddressee _addresseeUser;
    private readonly SeverityLevel _severityLevel;

    public AddresseeWithFilter(IAddressee addresseeUser, SeverityLevel severityLevel)
    {
        _addresseeUser = addresseeUser;
        _severityLevel = severityLevel;
    }

    public void ReceiveMessage(BaseMessage? baseMessage)
    {
        if (baseMessage is null)
            throw new ArgumentNullException(nameof(baseMessage));

        if (baseMessage.SeverityLevel >= _severityLevel)
            _addresseeUser.ReceiveMessage(baseMessage);
    }
}