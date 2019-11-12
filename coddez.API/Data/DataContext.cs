using coddez.API.Models;
using Microsoft.EntityFrameworkCore;

namespace coddez.API.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base (options){}
        public DbSet<User> Users { get; set; }
    }
}