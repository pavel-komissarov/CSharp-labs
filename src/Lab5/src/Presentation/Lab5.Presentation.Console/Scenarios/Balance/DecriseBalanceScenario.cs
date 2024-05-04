using Lab5.Application.Contracts.Users;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.Balance;

public class DecriseBalanceScenario : IScenario
{
    private IUserService _userService;

    public DecriseBalanceScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Decrease balance";

    public async Task Run()
    {
        decimal amount = AnsiConsole.Ask<decimal>("Enter amount to decrease");

        Task<UsersResult> result = _userService.RemoveMoney(amount);

        string message = (await result) switch
        {
            UsersResult.Success => "Successful decrease",
            UsersResult.Fail => "Not enough money",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");
    }
}