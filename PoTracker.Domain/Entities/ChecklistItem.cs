namespace PoTracker.Domain.Entities;

public class ChecklistItem
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public string Title { get; set; } = string.Empty;
    public bool IsDone { get; set; }

    public DateTime Date { get; set; }  // daily tracking

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}