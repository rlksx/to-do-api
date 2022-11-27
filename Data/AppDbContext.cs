
using Microsoft.EntityFrameworkCore;
using to_do_api.Models;

namespace to_do_api.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<ToDoModel> ToDoModels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite("DataSource=app.db;Cache=Shared");
    }
}