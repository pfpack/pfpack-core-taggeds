#nullable enable

namespace System
{
    partial struct Unit
    {
        public static bool Equals(Unit left, Unit right) => (left, right) switch
        {
            _ => true
        };

        public static bool operator ==(Unit left, Unit right) => (left, right) switch
        {
            _ => true
        };

        public static bool operator !=(Unit left, Unit right) => (left, right) switch
        {
            _ => false
        };

        public bool Equals(Unit other)
            =>
            true;

        public override bool Equals(object? obj)
            =>
            obj is Unit;

        public override int GetHashCode()
            =>
            HashCode.Combine(typeof(Unit));
    }
}
