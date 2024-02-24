using Domain.Entities.Users;
using Domain.Helpers;
using Domain.Interfaces;
using Spectre.Console;

namespace ConsolePresentation;

public class RegistrationsPage
{
    private readonly IUserService _userService;

    public RegistrationsPage(IUserService userService)
    {
        _userService = userService;
    }
    [Obsolete("Obsolete")]
    public async Task Display()
    {
        AnsiConsole.Clear();
        while (true)
        {
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Choose one of this options")
                    .PageSize(5) // Number of items visible at once
                    .AddChoices("Sign up", "Log in", "Exit")
                    .HighlightStyle(new Style(foreground: Color.Cyan1, background: Color.Blue))
            );
            switch (choice)
            {
                case "Sign up":
                    await SignUp();
                    break;
                case "Log in":
                    await LogIn();
                    break;
                case "Exit":
                    AnsiConsole.MarkupLine("[green]Good Bye[/]");
                    Environment.Exit(0);
                    break;
            }
        }
    }

    [Obsolete]
    private async Task SignUp()
    {
        AnsiConsole.Clear();
        while (true)
        {
            var name = AnsiConsole.Ask<string>("[blue]Name: [/]");
            while (!ValidationHelper.IsNameValid(name))
            {
                AnsiConsole.MarkupLine("[red]Invalid Name !!![/]");
                var choice = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Choose one of this options")
                        .PageSize(5) // Number of items visible at once
                        .AddChoices("Try again", "Already have an account", "Exit")
                        .HighlightStyle(new Style(foreground: Color.Violet, background: Color.Blue3))
                );
                switch (choice)
                {
                    case "Try again":
                        await SignUp();
                        break;
                    case "Already have an account":
                        await LogIn();
                        break;
                    case "Exit":
                        AnsiConsole.MarkupLine("[green]Good Bye[/]");
                        Environment.Exit(0);
                        break;
                }
            }
            var email = AnsiConsole.Ask<string>("[blue]Email: [/]");
            while (!ValidationHelper.IsEmailValid(email))
            {
                AnsiConsole.MarkupLine("[red]Invalid email !!![/]");
                var choice = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Choose one of this options")
                        .PageSize(5)
                        .AddChoices("Try again", "Already have an account", "Exit")
                        .HighlightStyle(new Style(foreground: Color.Violet, background: Color.Blue3))
                );
                switch (choice)
                {
                    case "Try again":
                        await SignUp();
                        break;
                    case "Already have an account":
                        await LogIn();
                        break;
                    case "Exit":
                        AnsiConsole.MarkupLine("[green]Good Bye[/]");
                        Environment.Exit(0);
                        break;
                }
            }
            var password = AnsiConsole.Prompt(new TextPrompt<string>("[blue]Password: [/]").PromptStyle("yellow").Secret());
            while (!ValidationHelper.IsPasswordValid(password))
            {
                AnsiConsole.MarkupLine("[red]Invalid password !!! " +
                                       "Password should be between 8 and 15 and " +
                                       "should contain at least one lowercase letter, one uppercase letter, one digit, and one special character[/]");
                var choice = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Choose one of this options")
                        .PageSize(5)
                        .AddChoices("Try again", "Already have an account", "Exit")
                        .HighlightStyle(new Style(foreground: Color.Violet, background: Color.Blue3))
                );
                switch (choice)
                {
                    case "Try again":
                        await SignUp();
                        break;
                    case "Already have an account":
                        await LogIn();
                        break;
                    case "Exit":
                        AnsiConsole.MarkupLine("[green]Good Bye[/]");
                        Environment.Exit(0);
                        break;
                }
            }
            var (hash, salt) = PasswordHasher.GenerateHash(password);
            try
            {
                var user = new UserCreationModel()
                {
                    Name = name,
                    Email = email,
                    Hash = hash,
                    Salt = salt
                };
                var existUser = await _userService.CreateAsync(user);

                AnsiConsole.MarkupLine($"[green]Welcomme {existUser.Name}[/]");
                Thread.Sleep(1500);

                await LogIn();
            }
            catch (Exception ex)
            {
                AnsiConsole.MarkupLine($"[red]{ex.Message}[/]");
                Thread.Sleep(1500);
                var choice = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Choose one of this options")
                        .PageSize(5)
                        .AddChoices("Try again", "Already have an account", "Exit")
                        .HighlightStyle(new Style(foreground: Color.Violet, background: Color.Blue3))
                );
                switch (choice)
                {
                    case "Try again":
                        await SignUp();
                        break;
                    case "Already have an account":
                        await LogIn();
                        break;
                    case "Exit":
                        AnsiConsole.MarkupLine("[green]Good Bye[/]");
                        Environment.Exit(0);
                        break;
                }
                break;
            }

        }
    }

    [Obsolete("Obsolete")]
    public async Task LogIn()
    {
        AnsiConsole.Clear();
        while (true)
        {
            var email = AnsiConsole.Ask<string>("[blue]Email: [/]");
            while (!ValidationHelper.IsEmailValid(email))
            {
                AnsiConsole.MarkupLine("[red]Invalid email !!![/]");
                var choice = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Choose one of this options")
                        .PageSize(5)
                        .AddChoices("Try again", "Create a new account", "Exit")
                        .HighlightStyle(new Style(foreground: Color.Violet, background: Color.Blue3))
                );
                switch (choice)
                {
                    case "Try again":
                        await SignUp();
                        break;
                    case "Create a new account":
                        await LogIn();
                        break;
                    case "Exit":
                        AnsiConsole.MarkupLine("[green]Good Bye[/]");
                        Environment.Exit(0);
                        break;
                }
            }
            var password = AnsiConsole.Prompt(new TextPrompt<string>("[blue]Password: [/]").PromptStyle("yellow").Secret());
            while (!ValidationHelper.IsPasswordValid(password))
            {
                AnsiConsole.MarkupLine("[red]Invalid password !!! " +
                                       "Password should be between 8 and 15 and " +
                                       "should contain at least one lowercase letter, one uppercase letter, one digit, and one special character[/]");
                var choice = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Choose one of this options")
                        .PageSize(5) // Number of items visible at once
                        .AddChoices("Try again", "Create a new account", "Exit")
                        .HighlightStyle(new Style(foreground: Color.Violet, background: Color.Blue3))
                );
                switch (choice)
                {
                    case "Try again":
                        await SignUp();
                        break;
                    case "Create a new account":
                        await LogIn();
                        break;
                    case "Exit":
                        AnsiConsole.MarkupLine("[green]Good Bye[/]");
                        Environment.Exit(0);
                        break;
                }
            }
            try
            {

                var existUser = await _userService.GetByEmailAsync(email);
                if (PasswordHasher.VerifyPassword(password, existUser.Hash, existUser.Salt))
                {
                    AnsiConsole.MarkupLine("[red]Wrong password!!![/]");
                    var choice = AnsiConsole.Prompt(
                        new SelectionPrompt<string>()
                            .Title("Choose one of this options")
                            .PageSize(5)
                            .AddChoices("Try again", "Create a new account", "Exit")
                            .HighlightStyle(new Style(foreground: Color.Violet, background: Color.Blue3))
                    );
                    switch (choice)
                    {
                        case "Try again":
                            await SignUp();
                            break;
                        case "Create a new account":
                            await LogIn();
                            break;
                        case "Exit":
                            AnsiConsole.MarkupLine("[green]Good Bye[/]");
                            Environment.Exit(0);
                            break;
                    }
                }


            }
            catch (Exception ex)
            {
                AnsiConsole.MarkupLine($"[red]{ex.Message}[/]");
                var choice = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Choose one of this options")
                        .PageSize(5)
                        .AddChoices("Try again", "Create a new account", "Exit")
                        .HighlightStyle(new Style(foreground: Color.Violet, background: Color.Blue3))
                );
                switch (choice)
                {
                    case "Try again":
                        await SignUp();
                        break;
                    case "Create a new account":
                        await LogIn();
                        break;
                    case "Exit":
                        AnsiConsole.MarkupLine("[green]Good Bye[/]");
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }

}