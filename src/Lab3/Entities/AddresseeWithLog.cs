using System;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Services;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class AddresseeWithLog : IAddressee
{
    private readonly IAddressee _addresseeUser;
    private readonly ILogger _logger;

    public AddresseeWithLog(IAddressee addresseeUser, ILogger logger)
    {
        _addresseeUser = addresseeUser;
        _logger = logger;
    }

    public void ReceiveMessage(BaseMessage baseMessage)
    {
        _addresseeUser.ReceiveMessage(baseMessage ?? throw new ArgumentNullException(nameof(baseMessage)));
        _logger.Write(baseMessage.Body);
    }
}