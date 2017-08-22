using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            :base(options)
        {            
            if(this.Database.IsSqlServer())
            {
                this.Database.Migrate();
            }
        }

        public DbSet<TodoItem> TodoItems { get;set; }
    }     
}