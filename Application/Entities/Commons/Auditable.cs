namespace Domain.Entities.Commons;

public class Auditable
{
    public long Id { get; set; }
    public DateTime CreateAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdateAt { get; set; }
    public DateTime DeletedAt { get; set; }
    public bool IsDeleted { get; set; }
}