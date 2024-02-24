using Domain.Entities.Commons;

namespace Domain.Entities.Jobs;

public class Job : Auditable
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Location { get; set; } = null!;
    public string RequiredSkills { get; set; } = null!;
    public string Salary { get; set; } = null!;
    public string EmployerInfo { get; set; } = null!;
}