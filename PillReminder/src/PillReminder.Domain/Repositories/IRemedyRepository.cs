using PillReminder.Domain.entities;

namespace PillReminder.Domain.Repositories
{
    public interface IRemedyRepository
    {
        Task<bool> RegisterNewRemedy(RemedyEntity remedy);
        Task<List<RemedyEntity>> FindAllRemedies(string userId);

        Task<RemedyEntity> SearchRemedyDetails(string remedyId);

        Task<bool> UpdateRemedyData(string remedyId, RemedyEntity remedy);

        Task<bool> DeleteRemedy(string remedyId);


    }
}
