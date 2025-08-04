
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data;

public class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
  public DbSet<TaskItem> Tasks => Set<TaskItem>();

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<TaskItem>().Property(t => t.Status).HasDefaultValue("A Fazer");
  }
}