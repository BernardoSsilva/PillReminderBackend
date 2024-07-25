using Microsoft.EntityFrameworkCore;
using PillReminder.Domain.entities;
using PillReminder.Domain.Repositories;

namespace PillReminder.Infrastructure.DataAccsess.Repositories
{
    internal class RemedyRepository : IRemedyRepository
    {
        private readonly PillReminderDbAccess _dbAccess;

        public RemedyRepository(PillReminderDbAccess dbAccess)
        {
            _dbAccess = dbAccess;
        }

        //register new remedy
        public async Task<bool> RegisterNewRemedy(RemedyEntity remedy)
        {
            await _dbAccess.AddAsync(remedy);
            return true;
        }

        // delete remedy
        public async Task<bool> DeleteRemedy(string remedyId, string userId)
        {
            var remedyToDelete = await _dbAccess.Remedies.FirstOrDefaultAsync(remedy => remedy.Id == remedyId && remedy.UserId == userId);
            if (remedyToDelete is null)
            {
                return false;
            }
            _dbAccess.Remedies.Remove(remedyToDelete);
            return true;
        }


        // find all remedies from user
        public async Task<List<RemedyEntity>> FindAllRemedies(string userId)
        {
            var remediesList = await _dbAccess.Remedies.Where(remedy => remedy.UserId == userId).ToListAsync();
            return remediesList;
        }



        // find unique remedy
        public async Task<RemedyEntity?> SearchRemedyDetails(string remedyId, string userId)
        {
            var remedy = await _dbAccess.Remedies.AsNoTracking().FirstOrDefaultAsync(remedy => remedy.Id == remedyId && remedy.UserId == userId);
            return remedy;
        }


        //update remedy
        public void UpdateRemedyData(RemedyEntity remedy)
        {
            _dbAccess.Remedies.Update(remedy);
        }
    }
}
