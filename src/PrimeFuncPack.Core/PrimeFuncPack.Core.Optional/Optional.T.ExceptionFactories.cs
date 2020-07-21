#nullable enable

namespace System
{
    partial struct Optional<T>
    {
        private static InvalidOperationException CreateNoPresentException()
            =>
            new InvalidOperationException("The optional does not have a present value.");
    }
}
