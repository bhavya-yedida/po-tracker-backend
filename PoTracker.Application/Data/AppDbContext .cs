using Microsoft.EntityFrameworkCore;
using PoTracker.Domain.Entities;

namespace PoTracker.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<TaskItem> Tasks { get; set; }
    public DbSet<ChecklistItem> ChecklistItems { get; set; }
    public DbSet<Note> Notes { get; set; }
}