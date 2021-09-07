#nullable enable

namespace System
{
    partial struct Optional<T>
    {
        private static InvalidOperationException CreateExpectedPresentException()
            =>
            new("The optional is expected to have a value.");
    }
}
