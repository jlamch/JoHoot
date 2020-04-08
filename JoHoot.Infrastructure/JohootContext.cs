using Johoot.Data;
using Microsoft.EntityFrameworkCore;

namespace Johoot.Infrastructure
{
  public class JohootContext : DbContext
  {
    public JohootContext(DbContextOptions<JohootContext> contextOptions)
        : base(contextOptions)
    {
    }

    public DbSet<Quize> Quizes { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Answer> Answers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
    }
  }
}
