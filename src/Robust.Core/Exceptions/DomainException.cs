namespace Robust.Core.Exceptions
{
    public class DomainException : Exception
    {
        internal List<string> _errors = new List<string>();

        public IReadOnlyCollection<string> Errors => _errors;

        public DomainException()
        {
        }

        public DomainException(string message, List<string> errors) : base(message)
        {
            _errors = errors;
        }

        public DomainException(string message) : base(message)
        {
        }

        public DomainException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
