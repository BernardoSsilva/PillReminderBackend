using PillReminder.Communication.remedies.responses;

namespace PillReminderApplication.UseCases.Remedy.Get.interfaces
{
    public interface IFindRemedyByIdUseCase
    {
        Task<RemedyDetailedJsonResponse> Execute(string remedyId, string token);
    }
}
