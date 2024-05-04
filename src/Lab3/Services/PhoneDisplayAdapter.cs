namespace Itmo.ObjectOrientedProgramming.Lab3.Services;

public class PhoneDisplayAdapter : IDisplay
{
    private readonly IPhoneDisplay _phoneDisplay;

    public PhoneDisplayAdapter(IPhoneDisplay phoneDisplay)
    {
        _phoneDisplay = phoneDisplay;
    }

    public void Paint(string text)
    {
        _phoneDisplay.ShowText(text);
    }
}