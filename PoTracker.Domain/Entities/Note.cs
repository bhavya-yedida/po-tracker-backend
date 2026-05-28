namespace PoTracker.Domain.Entities;

public class Note
{
    public int Id { get; set; }
    public Guid UserId { get; set; }

    public string? Content { get; set; }
    public string? Tags { get; set; }
    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }


}