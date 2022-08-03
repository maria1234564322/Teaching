using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace InterviewWebApp.Controllers
{
    public class InterviewAppDbContext : DbContext
    {
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Category> Categorys { get; set; }
        public virtual DbSet<Answer> Answers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog= InterviewAppDb;");
        }

        public InterviewAppDbContext()
        {
            Database.EnsureCreated();
        }
    }
}