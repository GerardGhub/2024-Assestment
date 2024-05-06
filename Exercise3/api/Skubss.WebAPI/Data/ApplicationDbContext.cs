using Microsoft.EntityFrameworkCore;
using Skubss.WebAPI.Models;

namespace Skubss.WebAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
