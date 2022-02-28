using CSMA_API.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CSMA_API.Application.Common.Interfaces
{
    public interface ISalonDbContext
    {
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<BlogPost> Posts { get; set; }
        public DbSet<EmployeeWorkingHours> WorkingHours { get; set; }

        ChangeTracker GetChangeTracker();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
