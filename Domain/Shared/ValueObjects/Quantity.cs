namespace Domain.Shared.ValueObjects
{
    public class Quantity
    {
        public int Value { get; private set; }

        public Quantity(int value)
        {
            if (!IsValid(value))
            {
                throw new ArgumentException("Age is not valid");
            }

            Value = value;
        }

        public void AddOne() => Value += 1;

        public static bool IsValid(int value) => 0 <= value && value <= 2147483647;

        public override bool Equals(object obj) => obj is Quantity other && Value == other.Value;

        public override int GetHashCode() => Value.GetHashCode();
    }
}
