using Microsoft.EntityFrameworkCore;
using TaskAppWeb.Models;

namespace TaskAppWeb.Data
{
    public class ApplicationDbContext : DbContext
    {

        //constructor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<TaskList> TaskLists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TaskList>().HasData(
                new TaskList {Id=1, Name= "Do Exercise", Priority = "High", isCompleted = true },
                new TaskList { Id = 2, Name = "Make Dinner", Priority = "Medium", isCompleted = false },
                new TaskList { Id = 3, Name = "Have Lunch", Priority = "Low", isCompleted = false },
                new TaskList { Id = 4, Name = "Read", Priority = "High", isCompleted = true }
                );
        }

    }
}
