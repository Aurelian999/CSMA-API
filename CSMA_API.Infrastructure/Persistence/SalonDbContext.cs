using CSMA_API.Application.Common.Interfaces;
using CSMA_API.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CSMA_API.Infrastructure.Persistence
{
    public class SalonDbContext : DbContext, ISalonDbContext
    {
        public DbSet<Appointment> Appointments { get; set; }

        public SalonDbContext(DbContextOptions<SalonDbContext> options) : base(options)
        {

        }

        public ChangeTracker GetChangeTracker()
        {
            return base.ChangeTracker;
        }
    }
}
