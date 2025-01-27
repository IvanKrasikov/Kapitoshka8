namespace Domain.Shared.ValueObjects
{
    public class ParentId
    {
        public int Value { get; private set; }

        public ParentId(int value)
        {
            if (!IsValid(value))
            {
                throw new ArgumentException("Age is not valid");
            }

            Value = value;
        }

        public static bool IsValid(int value) => 0 <= value && value <= 2147483647;

        public override bool Equals(object obj) => obj is ParentId other && Value == other.Value;

        public override int GetHashCode() => Value.GetHashCode();
    }
}
