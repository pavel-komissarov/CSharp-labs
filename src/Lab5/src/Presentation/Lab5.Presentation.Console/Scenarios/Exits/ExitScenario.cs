namespace Lab5.Presentation.Console.Scenarios.Exits;

public class ExitScenario : IScenario
{
    public string Name => "Exit";

    public Task Run()
    {
        Environment.Exit(0);
        return Task.CompletedTask;
    }
}