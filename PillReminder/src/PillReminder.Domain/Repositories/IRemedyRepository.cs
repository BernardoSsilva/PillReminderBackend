using PillReminder.Domain.entities;

namespace PillReminder.Domain.Repositories
{
    public interface IRemedyRepository
    {
        Task<bool> RegisterNewRemedy(RemedyEntity remedy);
        Task<List<RemedyEntity>> FindAllRemedies(string userId);

        Task<RemedyEntity?> SearchRemedyDetails(string remedyId, string userId);

        void UpdateRemedyData( RemedyEntity remedy);

        Task<bool> DeleteRemedy(string remedyId, string userId);


    }
}
