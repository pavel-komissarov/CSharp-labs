namespace Itmo.ObjectOrientedProgramming.Lab3.Services;

public class TelegramAdepter : IMessenger
{
    private readonly ITelegram _telegram;

    public TelegramAdepter(ITelegram telegram)
    {
        _telegram = telegram;
    }

    public void WriteText(string text)
    {
        _telegram.PostMessage(text);
    }
}