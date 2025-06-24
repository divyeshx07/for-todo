using Microsoft.EntityFrameworkCore;
using TodoApi.Models; // if your TodoItem.cs is under Models/

namespace TodoApi.Data; // ✅ THIS MUST BE PRESENT

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<TodoItem> Todos => Set<TodoItem>();
}
