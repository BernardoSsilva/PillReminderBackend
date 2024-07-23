
using System.Net;

namespace PillReminder.Exception.exceptions
{
    public class NotFoundException : AppException
    {
        private string Error { get; set; }
        public NotFoundException(string message) : base(message)
        {
            Error = message;
        }
        public override int statusCode => (int)HttpStatusCode.NotFound;

        public override List<string> getErrors()
        {
            return [Error];
        }
    }
}
