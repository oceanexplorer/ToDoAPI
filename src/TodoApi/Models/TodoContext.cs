using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            :base(options)
        {            
            if(this.Database.IsNpgsql())
            {
                this.Database.Migrate();
            }
        }

        public DbSet<TodoItem> TodoItems { get;set; }
    }     
}