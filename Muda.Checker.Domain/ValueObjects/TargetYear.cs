namespace Muda.Checker.Domain.ValueObjects
{
    public sealed class TargetYear : ValueObject<TargetYear>
    {
        public static readonly TargetYear Empty = new TargetYear();
        private TargetYear()
        {
            DisplayValue = "入力してください";
        }

        public TargetYear(int value)
        {
            Value = value;
            DisplayValue = value.ToString("0000");
        }
        public int Value { get; }
        public string DisplayValue { get; }
        protected override bool EqualsCore(TargetYear other)
        {
            return Value == other.Value;
        }
    }
}
