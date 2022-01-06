namespace Robust.Domain.Entities
{
    public abstract class Base
    {
        public long Id { get; set; }

        internal List<string> _errors = new List<string>();

        public IReadOnlyCollection<string> Errors { get => _errors; }

        public abstract bool Validate();
    }
}
