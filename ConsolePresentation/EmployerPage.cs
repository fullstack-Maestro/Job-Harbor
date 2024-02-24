using Domain.Interfaces;
using Spectre.Console;

namespace ConsolePresentation;

public class EmployerPage
{
    private readonly IUserService _userService;
    public EmployerPage(IUserService userService)
    {
        _userService = userService;
    }
    public async Task Display()
    {
        while (true)
        {
            AnsiConsole.Clear();
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Choose one of this options")
                    .PageSize(5)
                    .AddChoices("Post a job", "Get all applicants", "Exit")
                    .HighlightStyle(new Style(foreground: Color.Cyan1, background: Color.Blue))
            );
            switch (choice)
            {
                case "Post a job":

                    break;
                case "Get all applicants":

                    break;
                case "Exit":
                    AnsiConsole.MarkupLine("[green]Good Bye[/]");
                    Environment.Exit(0);
                    break;
            }
        }
    }
}