using Lab5.Application.Contracts.Users;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.Balance;

public class IncreseBalanceScenario : IScenario
{
    private IUserService _userService;

    public IncreseBalanceScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Increase balance";

    public async Task Run()
    {
        decimal amount = AnsiConsole.Ask<decimal>("Enter amount to increase");

        await _userService.AddMoney(amount);

        AnsiConsole.Ask<string>("Ok");
    }
}