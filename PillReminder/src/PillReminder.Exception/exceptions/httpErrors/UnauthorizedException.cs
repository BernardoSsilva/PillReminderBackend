using System.Net;

namespace PillReminder.Exception.exceptions.httpErrors
{
    public class UnauthorizedException : AppExceptions
    {
        private string Error { get; set; }
        public UnauthorizedException(string message) : base(message)
        {
            Error = message;
        }
        public override int statusCode => (int)HttpStatusCode.Unauthorized;

        public override List<string> getErrors()
        {
            return [Error];
        }
    }
}
