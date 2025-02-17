namespace Muda.Checker.Domain.ValueObjects
{
    public sealed class StatusMessage : ValueObject<StatusMessage>
    {
        public static readonly StatusMessage Empty = new StatusMessage();
        private StatusMessage()
        {
            Value = string.Empty;
            ForegroundColor = "White";
        }
        public StatusMessage(string value, bool hasError = false)
        {
            Value = hasError ? value : value + "に保存しました";
            ForegroundColor = hasError ? "Red" : "Green";
            FilePath = hasError ? null : value;
        }
        public string Value { get; }
        public string? FilePath { get; }
        public string ForegroundColor { get; }
        protected override bool EqualsCore(StatusMessage other)
        {
            return Value == other.Value;
        }
    }
}
