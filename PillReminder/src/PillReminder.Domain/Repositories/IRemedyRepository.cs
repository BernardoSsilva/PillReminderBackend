using PillReminder.Domain.entities;

namespace PillReminder.Domain.Repositories
{
    public interface IRemedyRepository
    {
        Task RegisterNewRemedy(RemedyEntity remedy);
        Task<List<RemedyEntity>> FindAllRemedies(string userId);

        Task<RemedyEntity> SearchRemedyDetails(string remedyId);

        Task UpdateRemedyData(string remedyId, RemedyEntity remedy);

        Task DeleteRemedy(string remedyId);


    }
}
