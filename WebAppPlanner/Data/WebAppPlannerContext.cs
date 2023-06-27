using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAppPlanner.Models;

namespace WebAppPlanner.Data
{
    public class WebAppPlannerContext : DbContext
    {
        public WebAppPlannerContext (DbContextOptions<WebAppPlannerContext> options)
            : base(options)
        {
        }

        public DbSet<WebAppPlanner.Models.Category> Category { get; set; } = default!;

        public DbSet<WebAppPlanner.Models.MyTask>? MyTask { get; set; }

        public DbSet<WebAppPlanner.Models.PriorityTask>? PriorityTask { get; set; }
    }
}
