using Microsoft.EntityFrameworkCore;
using PillReminder.Domain.entities;

namespace PillReminder.Infrastructure
{
    public class PillReminderDbAccess : DbContext
    {
        public PillReminderDbAccess(DbContextOptions<PillReminderDbAccess> options) : base(options)
        {
        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<RemedyEntity> Remedies { get; set; }
        public DbSet<ImageEntity> Images { get; set; }
    }
}
