using PillReminder.Communication.remedies.requests;
using PillReminder.Communication.remedies.responses;

namespace PillReminderApplication.UseCases.Remedy.Post.Interface
{
    public interface ICreateNewRemedyUseCase
    {
        Task<RemedyShortJsonResponse> Execute(RemedyJsonRequest remedyData, string token);
    }
}
