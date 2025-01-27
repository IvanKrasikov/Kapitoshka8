using System.Text.RegularExpressions;

namespace Domain.Shared.ValueObjects
{
    public class Name
    {
        private static readonly Regex ValidationRegex = new Regex(
        @"^[А-Яа-яA-Za-z]+",
        RegexOptions.Singleline | RegexOptions.Compiled);

        public Name(string value)
        {
            if (!IsValid(value))
            {
                throw new ArgumentException("Name is not valid");
            }

            Value = value;
        }

        public string Value { get; private set; }

        public static bool IsValid(string value) => !string.IsNullOrWhiteSpace(value) && ValidationRegex.IsMatch(value);

        public override bool Equals(object obj) => obj is Name other &&
                   StringComparer.Ordinal.Equals(Value, other.Value);

        public override int GetHashCode() => StringComparer.Ordinal.GetHashCode(Value);

        public override string ToString() => Value;
    }
}
