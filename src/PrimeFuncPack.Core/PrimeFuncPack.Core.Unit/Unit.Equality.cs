#nullable enable

namespace System
{
    partial struct Unit
    {
        public static bool Equals(in Unit valueA, in Unit valueB) => true;

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

        public override int GetHashCode() => default;
    }
}
