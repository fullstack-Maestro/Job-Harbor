using Spectre.Console;

namespace ConsolePresentation;

public class ApplicationPage
{
    private readonly ApplicantPage _applicantPage;
    private readonly EmployerPage _employerPage;
    private readonly RegistrationsPage _registrationsPage;

    public ApplicationPage(ApplicantPage applicantPage, EmployerPage employerPage, RegistrationsPage registrationsPage)
    {
        this._applicantPage = applicantPage;
        this._employerPage = employerPage;
        this._registrationsPage = registrationsPage;
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
                    .PageSize(5)
                    .AddChoices("Employer", "Applicant", "Log out")
                    .HighlightStyle(new Style(foreground: Color.Cyan1, background: Color.Blue))
            );
            switch (choice)
            {
                case "Employer":
                    await _employerPage.Display();
                    break;
                case "Applicant":
                    await _applicantPage.Display();
                    break;
                case "Log out":
                    await _registrationsPage.Display();
                    break;
            }
        }
    }


}