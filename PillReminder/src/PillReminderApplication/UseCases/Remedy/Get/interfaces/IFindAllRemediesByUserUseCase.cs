using PillReminder.Communication.remedies.responses;

namespace PillReminderApplication.UseCases.Remedy.Get.interfaces
{
    public interface IFindAllRemediesByUserUseCase
    {
        Task<MultiplesRemediesJsonResponse> Execute(string token);
    }
}
