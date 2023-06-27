using Microsoft.EntityFrameworkCore;

namespace WebAppPlanner.Models
{
    public class PlannerContext : DbContext
    {
        public virtual DbSet<PriorityTask> PriorityTasks { get; set; }
        public virtual DbSet<MyTask> Tasks { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public PlannerContext(DbContextOptions<PlannerContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}