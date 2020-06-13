#nullable enable

namespace System
{
    partial struct Unit
    {
        private const bool EqualsResult = true;

        private const bool NotEqualsResult = false;

        public static bool Equals(in Unit valueA, in Unit valueB)
            =>
            EqualsResult;

        public static bool operator ==(in Unit valueA, in Unit valueB)
            =>
            EqualsResult;

        public static bool operator !=(in Unit valueA, in Unit valueB)
            =>
            NotEqualsResult;

        public bool Equals(Unit other)
            =>
            EqualsResult;

        public override bool Equals(object? obj) => obj switch
        {
            Unit _ =>
            EqualsResult,

            _ => false
        };

        public override int GetHashCode() => default;
    }
}
