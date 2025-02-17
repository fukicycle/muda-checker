using Muda.Checker.Domain.Exceptions;

namespace Muda.Checker.Domain.ValueObjects
{
    public sealed class TargetDirectory : ValueObject<TargetDirectory>
    {
        public static readonly TargetDirectory Empty = new TargetDirectory();
        private TargetDirectory()
        {
            Value = "選択してください";
        }
        public TargetDirectory(string value)
        {
            if (Directory.Exists(value))
            {
                Value = value;
            }
            else
            {
                throw new TargetDirectoryException($"対象のフォルダは見つからないかアクセスできません。{value}");
            }
        }
        public string Value { get; }
        protected override bool EqualsCore(TargetDirectory other)
        {
            return Value == other.Value;
        }
    }
}
