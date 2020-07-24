#nullable enable

namespace System
{
    partial struct TaggedUnion<TTag, TFirst, TSecond>
    {
        private static InvalidOperationException CreateNotInitializedException()
            =>
            new InvalidOperationException("The tagged union is not initialized.");

        private static InvalidOperationException CreateExpectValidInvariantException()
            =>
            new InvalidOperationException("The tagged union is expected to have valid invariant.");
    }
}
