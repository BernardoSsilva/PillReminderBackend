namespace PillReminderApplication.UseCases.Remedy.Delete.interfaces
{
    public interface IDeleteRemedyUseCase
    {
        Task Execute(string remedyId, string token);
    }
}
