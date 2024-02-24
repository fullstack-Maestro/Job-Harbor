using Domain.Interfaces;
using Domain.Services;

namespace ConsolePresentation;

public class MainPage
{
    private readonly IUserService _userService;
    private readonly IJobService _jobService;

    private readonly ApplicantPage _applicantPage;
    private readonly JobPage _jobPage;
    private readonly RegistrationsPage _registrationsPage;
    private readonly ApplicationPage _applicationPage;
    private readonly EmployerPage _employerPage;

    public MainPage()
    {
        _userService = new UserService();
        _jobService = new JobService();

        _applicantPage = new ApplicantPage(_userService, _jobService);
        _employerPage = new EmployerPage(_userService);
        _jobPage = new JobPage(_jobService);
        _registrationsPage = new RegistrationsPage(_userService);
        _applicationPage = new ApplicationPage(_applicantPage, _employerPage, _registrationsPage);
    }

    [Obsolete]
    public async Task Run()
    {
        await _registrationsPage.Display();
    }
}