using System.Net;

namespace PillReminder.Exception.exceptions.httpErrors
{
    public class BadRequestException : AppException
    {
        private string Error { get; set; }
        public BadRequestException(string message) : base(message)
        {
            Error = message;
        }
        public override int statusCode => (int)HttpStatusCode.BadRequest;

        public override List<string> getErrors()
        {
            return [Error];
        }
    }
}
