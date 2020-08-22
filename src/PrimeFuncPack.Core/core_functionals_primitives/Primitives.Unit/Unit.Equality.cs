#nullable enable

namespace System
{
    partial struct Unit
    {
        public static bool Equals(Unit valueA, Unit valueB)
            =>
            (valueA, valueB) switch { _ => true };

        public static bool operator ==(in Unit valueA, in Unit valueB)
            =>
            Equals(valueA, valueB);

        public static bool operator !=(in Unit valueA, in Unit valueB)
            =>
            Equals(valueA, valueB) is false;

        public bool Equals(Unit other)
            =>
            Equals(this, other);

        public override bool Equals(object? obj)
            =>
            obj is Unit other &&
            Equals(this, other);

        public override int GetHashCode()
            =>
            HashCode.Combine(EqualityContract);

        private static Type EqualityContract => typeof(Unit);
    }
}
