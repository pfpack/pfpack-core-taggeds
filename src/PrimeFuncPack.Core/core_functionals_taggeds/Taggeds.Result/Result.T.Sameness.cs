#nullable enable

namespace System
{
    partial struct Result<TSuccess, TFailure>
    {
        public static bool Same(Result<TSuccess, TFailure> resultA, Result<TSuccess, TFailure> resultB)
            =>
            TaggedUnion<TSuccess, TFailure>.Same(resultA.union, resultB.union);

        public bool Same(Result<TSuccess, TFailure> other)
            =>
            Same(this, other);

        public int GetSamenessHashCode()
            =>
            HashCode.Combine(SamenessContract, union);

        private static Type SamenessContract => typeof(Result<TSuccess, TFailure>);
    }
}
