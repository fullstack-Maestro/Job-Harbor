using Domain.Interfaces;
using Spectre.Console;

namespace ConsolePresentation;

public class ApplicantPage
{
    private readonly IUserService _userService;
    private readonly IJobService _jobService;
    public ApplicantPage(IUserService userService, IJobService jobService)
    {
        this._userService = userService;
        this._jobService = jobService;
    }
    public async Task Display()
    {
        AnsiConsole.Clear();
        while (true)
        {
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Choose one of this options")
                    .PageSize(5)
                    .AddChoices("Apply to a job", "View all jobs", "Exit")
                    .HighlightStyle(new Style(foreground: Color.Cyan1, background: Color.Blue))
            );
            switch (choice)
            {
                case "Apply to a job":

                    break;
                case "View all jobs":
                    await ViewAllJobs();
                    break;
                case "Exit":
                    AnsiConsole.MarkupLine("[green]Good Bye[/]");
                    Environment.Exit(0);
                    break;
            }
        }
    }

    public async Task ViewAllJobs()
    {
        var jobs = await _jobService.GetAllAsync();
        var table = new Table();

        table.Title("Jobs")
            .BorderColor(Color.Blue)
            .AsciiBorder();

        table.AddColumn("Title");
        table.AddColumn("Description");
        table.AddColumn("Location");
        table.AddColumn("RequiredSkills");
        table.AddColumn("Salary");
        table.AddColumn("EmployerInfo");

        foreach (var job in jobs)
            table.AddRow(job.Title, job.Description, job.Location, job.RequiredSkills, job.Salary, job.EmployerInfo);

        table.Border = TableBorder.Rounded;
        table.Centered();
    }
}