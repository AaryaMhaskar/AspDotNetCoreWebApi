using AspCoreWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AspCoreWebApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Emp> emps { get; set; }
    }
}
