using PillReminder.Domain;

namespace PillReminder.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly PillReminderDbAccess _dbAccess;

        public UnitOfWork(PillReminderDbAccess DbAccess)
        {
            _dbAccess = DbAccess;
        }
        public async Task Commit()
        {
            await _dbAccess.SaveChangesAsync();
        }
    }
}
