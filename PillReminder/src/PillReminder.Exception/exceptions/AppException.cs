namespace PillReminder.Exception.exceptions
{
    public abstract class AppExceptions:SystemException
    {
        protected AppExceptions(string message) : base(message)
        {

        }

        public abstract int statusCode { get; }
        public abstract List<string> getErrors();
    }
}
