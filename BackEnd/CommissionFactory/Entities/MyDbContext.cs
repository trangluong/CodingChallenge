using Microsoft.EntityFrameworkCore;

namespace CommissionFactory.Entities
{
    public class MyDbContext : DbContext 
    {
        public MyDbContext(DbContextOptions options): base(options) { }
        public DbSet<Tasks> Tasks { get; set; }
    }
}
