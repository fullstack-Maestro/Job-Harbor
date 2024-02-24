using Domain.Interfaces;

namespace ConsolePresentation;

public class JobPage
{
    private readonly IJobService _jobService;
    public JobPage(IJobService jobService)
    {
        this._jobService = jobService;
    }
}