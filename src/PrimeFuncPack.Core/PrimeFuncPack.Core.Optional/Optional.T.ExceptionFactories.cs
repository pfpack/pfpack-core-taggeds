#nullable enable

namespace System
{
    partial struct Optional<T>
    {
        private static InvalidOperationException CreateExpectedToHaveValueException()
            =>
            new InvalidOperationException("The optional is expected to have a value.");
    }
}
