using Lab5.Application.Contracts.Users;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.Balance;

public class ShowHistoryScenario : IScenario
{
    private readonly IUserService _userService;

    public ShowHistoryScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Show history";

    public async Task Run()
    {
        Task<string> history = _userService.ShowHistory();

        AnsiConsole.WriteLine($"History:\n{await history}");

        AnsiConsole.Ask<string>("Ok");
    }
}