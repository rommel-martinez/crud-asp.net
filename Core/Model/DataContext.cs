using Microsoft.EntityFrameworkCore;

namespace CRUD.Core.Model
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<UserModel> Users { get; set; }
    }
}