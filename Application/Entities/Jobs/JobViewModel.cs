namespace Domain.Entities.Jobs;

public class JobViewModel
{
    public long Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Location { get; set; } = null!;
    public string RequiredSkills { get; set; } = null!;
    public string Salary { get; set; } = null!;
    public string EmployerInfo { get; set; } = null!;
}