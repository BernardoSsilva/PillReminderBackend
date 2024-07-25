using PillReminder.Communication.remedies.requests;

namespace PillReminderApplication.UseCases.Remedy.Put.Interfaces
{
    public interface IUpdateRemedyUseCase
    {
        Task Execute(RemedyJsonRequest requestData, string remedyId, string token);
    }
}
