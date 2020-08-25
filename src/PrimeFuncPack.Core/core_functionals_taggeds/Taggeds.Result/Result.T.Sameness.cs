#nullable enable

namespace System
{
    partial struct Result<TSuccess, TFailure>
    {
        public static bool Same(Result<TSuccess, TFailure> resultA, Result<TSuccess, TFailure> resultB)
            =>
            TaggedUnion.Same(resultA.SamenessUnion, resultB.SamenessUnion);

        public bool Same(Result<TSuccess, TFailure> other)
            =>
            Same(this, other);

        public int GetSamenessHashCode()
            =>
            HashCode.Combine(SamenessContract, SamenessUnion);

        private static Type SamenessContract => typeof(Result<TSuccess, TFailure>);

        private TaggedUnion<TSuccess, TFailure> SamenessUnion => unionRaw;
    }
}
