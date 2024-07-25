using System.Net;

namespace PillReminder.Exception.exceptions
{
    public class ValidationErrorsException : AppExceptions
    {
        private List<string> Errors { get; set; }
        public ValidationErrorsException(List<string> messages) : base(string.Empty)
        {
            Errors = messages;
        }
        public override int statusCode => (int)HttpStatusCode.BadRequest;

        public override List<string> getErrors()
        {
            return Errors;
        }
    }
}
