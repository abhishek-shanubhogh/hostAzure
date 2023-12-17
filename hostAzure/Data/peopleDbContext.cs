using hostAzure.Models;
using Microsoft.EntityFrameworkCore;

namespace hostAzure.Data
{
    public class peopleDbContext : DbContext
    {
        public peopleDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<peopleData> People   {get;set;}
    }
}
