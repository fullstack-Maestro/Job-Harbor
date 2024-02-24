using Domain.Entities.Commons;

namespace Domain.Entities.Applications;

public class Application : Auditable
{
    public string ApplicantsInfo { get; set; }
    public string AccountLinks { get; set; }
}