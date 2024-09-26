using Microsoft.EntityFrameworkCore;
using TheMutants.Models;

namespace TheMutants.Data
{
    public class QuestionDbContext : DbContext
    {

        public DbSet<Question> Questions { get; set; }

        public QuestionDbContext(DbContextOptions<QuestionDbContext> options) : base(options)
        {

        }
    }
}
