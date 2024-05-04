using Lab5.Application.Contracts.Users;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.Login;

public class LoginScenario : IScenario
{
    private readonly IUserService _userService;

    public LoginScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Login";

    public async Task Run()
    {
        string username = AnsiConsole.Ask<string>("Enter your username");
        string pin = AnsiConsole.Ask<string>("Enter your pin");

        Task<UsersResult> result = _userService.Login(username, pin);

        string message = await result switch
        {
            UsersResult.Success => "Successful login",
            UsersResult.Fail => "User not found",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");
    }
}