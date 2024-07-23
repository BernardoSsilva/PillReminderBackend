namespace PillReminder.Domain
{
    public interface IUnitOfWork
    {

            Task Commit();
    }
}
