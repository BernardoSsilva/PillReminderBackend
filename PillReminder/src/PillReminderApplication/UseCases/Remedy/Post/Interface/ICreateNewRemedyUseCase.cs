using PillReminder.Communication.remedies.requests;

namespace PillReminderApplication.UseCases.Remedy.Post.Interface
{
    public interface ICreateNewRemedyUseCase
    {
        Task Execute(RemedyJsonRequest remedyData);
    }
}
