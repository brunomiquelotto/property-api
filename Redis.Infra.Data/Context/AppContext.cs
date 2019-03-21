using Microsoft.EntityFrameworkCore;
using Redis.Domain.Entities;

namespace Redis.Infra.Data.Context
{
    public class AppContext : DbContext
    {
        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyUnity> PropertyUnities { get; set; }
        public DbSet<Realtor> Realtor { get; set; }
    }
}
