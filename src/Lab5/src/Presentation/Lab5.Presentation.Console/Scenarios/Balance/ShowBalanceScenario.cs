using Lab5.Application.Contracts.Users;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.Balance;

public class ShowBalanceScenario : IScenario
{
    private readonly IUserService _userService;

    public ShowBalanceScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Show balance";

    public async Task Run()
    {
        Task<string> balance = _userService.ShowBalance();

        AnsiConsole.WriteLine($"Your balance is {await balance}");

        AnsiConsole.Ask<string>("Ok");
    }
}