using CSMA_API.Application.Common.Interfaces;
using CSMA_API.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CSMA_API.Infrastructure.Persistence
{
    public class SalonDbContext : IdentityDbContext, ISalonDbContext
    {
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<BlogPost> Posts { get; set; }
        public DbSet<EmployeeWorkingHours> WorkingHours { get; set; }

        public SalonDbContext(DbContextOptions<SalonDbContext> options) : base(options)
        {

        }

        public ChangeTracker GetChangeTracker()
        {
            return base.ChangeTracker;
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {
            builder.Properties<DateOnly>()
                .HaveConversion<DateOnlyConverter>()
                .HaveColumnType("date");

            builder.Properties<TimeOnly>()
                .HaveConversion<TimeOnlyConverter>()
                .HaveColumnType("date");

            builder.Properties<DateOnly?>()
                .HaveConversion<NullableDateOnlyConverter>()
                .HaveColumnType("date");

            builder.Properties<TimeOnly?>()
                .HaveConversion<NullableTimeOnlyConverter>()
                .HaveColumnType("date");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

    /// <summary>
    /// Converts <see cref="DateOnly" /> to <see cref="DateTime"/> and vice versa.
    /// </summary>
    public class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
    {
        /// <summary>
        /// Creates a new instance of this converter.
        /// </summary>
        public DateOnlyConverter() : base(
                d => d.ToDateTime(TimeOnly.MinValue),
                d => DateOnly.FromDateTime(d))
        { }
    }

    /// <summary>
    /// Converts <see cref="TimeOnly" /> to <see cref="DateTime"/> and vice versa.
    /// </summary>
    public class TimeOnlyConverter : ValueConverter<TimeOnly, DateTime>
    {
        /// <summary>
        /// Creates a new instance of this converter.
        /// </summary>
        public TimeOnlyConverter() : base(
                t => DateTime.MinValue.Add(t.ToTimeSpan()),
                t => TimeOnly.FromDateTime(t))
        { }
    }

    /// <summary>
    /// Converts <see cref="DateOnly?" /> to <see cref="DateTime?"/> and vice versa.
    /// </summary>
    public class NullableDateOnlyConverter : ValueConverter<DateOnly?, DateTime?>
    {
        /// <summary>
        /// Creates a new instance of this converter.
        /// </summary>
        public NullableDateOnlyConverter() : base(
            d => d == null
                ? null
                : new DateTime?(d.Value.ToDateTime(TimeOnly.MinValue)),
            d => d == null
                ? null
                : new DateOnly?(DateOnly.FromDateTime(d.Value)))
        { }
    }

    /// <summary>
    /// Converts <see cref="TimeOnly?" /> to <see cref="DateTime?"/> and vice versa.
    /// </summary>
    public class NullableTimeOnlyConverter : ValueConverter<TimeOnly?, DateTime?>
    {
        /// <summary>
        /// Creates a new instance of this converter.
        /// </summary>
        public NullableTimeOnlyConverter() : base(
            t => t == null
                ? null
                : DateTime.MinValue.Add(t.Value.ToTimeSpan()),
            d => d == null
                ? null
                : TimeOnly.FromDateTime(d.Value))
        { }
    }
}
