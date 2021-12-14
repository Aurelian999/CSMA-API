using CSMA_API.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CSMA_API.Application.Common.Interfaces
{
    public interface ISalonDbContext
    {
        public DbSet<Appointment> Appointments { get; set; }

        ChangeTracker GetChangeTracker();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
