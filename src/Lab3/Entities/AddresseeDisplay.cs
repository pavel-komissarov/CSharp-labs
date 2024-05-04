using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Services;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class AddresseeDisplay : IAddressee
{
    private readonly IDisplay _display;

    public AddresseeDisplay(IDisplay display)
    {
        _display = display;
    }

    public void ReceiveMessage(BaseMessage baseMessage)
    {
         _display.Paint($"Title: {baseMessage?.Title}\nBody: {baseMessage?.Body}");
    }
}