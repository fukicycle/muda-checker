namespace Muda.Checker.Domain.ValueObjects
{
    public sealed class StatusMessage : ValueObject<StatusMessage>
    {
        public StatusMessage(string value, bool hasError = false)
        {
            Value = value;
            ForegroundColor = hasError ? "Red" : "Green";
        }
        public string Value { get; }
        public string ForegroundColor { get; }
        protected override bool EqualsCore(StatusMessage other)
        {
            return Value == other.Value;
        }
    }
}
