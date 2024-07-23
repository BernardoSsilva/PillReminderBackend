using Microsoft.EntityFrameworkCore;
using PillReminder.Domain.entities;
using PillReminder.Domain.Repositories;

namespace PillReminder.Infrastructure.Repositories
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
        public async Task<bool> DeleteRemedy(string remedyId)
        {
            var remedyToDelete = await _dbAccess.Remedies.FirstOrDefaultAsync(remedy => remedy.Id == remedyId);
            if(remedyToDelete is null)
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
        public async Task<RemedyEntity?> SearchRemedyDetails(string remedyId)
        {
            var remedy = await _dbAccess.Remedies.AsNoTracking().FirstOrDefaultAsync(remedy => remedy.Id == remedyId);
            return remedy;
        }


        //update remedy
        public void UpdateRemedyData( RemedyEntity remedy)
        {
           _dbAccess.Remedies.Update(remedy);
        }
    }
}
