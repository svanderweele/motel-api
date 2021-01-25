using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Motel.Models;

namespace Motel.Data
{
    public class MotelContext : DbContext
    {
        public MotelContext(DbContextOptions<MotelContext> options) : base(options)
        {
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {

            var updatedEntities = ChangeTracker.Entries().Where(entry => entry.Entity is LoggingEntity && (entry.State == EntityState.Added || entry.State == EntityState.Modified));

            foreach (var entityEntry in updatedEntities)
            {
                ((LoggingEntity)entityEntry.Entity).UpdatedAt = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((LoggingEntity)entityEntry.Entity).CreatedAt = DateTime.Now;
                }



                if (entityEntry.State == EntityState.Deleted)
                {
                    ((LoggingEntity)entityEntry.Entity).DeletedAt = DateTime.Now;
                }
            }
            return (await base.SaveChangesAsync(true, cancellationToken));
        }


        public DbSet<Booking> Bookings { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
    }
}