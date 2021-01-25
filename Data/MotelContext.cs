using Microsoft.EntityFrameworkCore;
using Motel.Models;

namespace Motel.Data
{
    public class MotelContext : DbContext
    {
        public MotelContext(DbContextOptions<MotelContext> options) : base(options)
        {
        }

        public DbSet<Room> Rooms { get; set; }
    }
}