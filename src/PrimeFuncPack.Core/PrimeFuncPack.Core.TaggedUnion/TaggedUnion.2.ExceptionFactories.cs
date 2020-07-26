#nullable enable

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        private static InvalidOperationException CreateNotInitializedException()
            =>
            new InvalidOperationException("The tagged union is not initialized.");

        private static InvalidOperationException CreateExpectedValidInvariantException()
            =>
            new InvalidOperationException("The tagged union is expected to have the valid invariant.");
    }
}
