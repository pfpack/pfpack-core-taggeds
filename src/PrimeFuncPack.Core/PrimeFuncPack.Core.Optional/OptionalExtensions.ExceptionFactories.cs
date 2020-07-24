#nullable enable

namespace System
{
    partial class OptionalExtensions
    {
        private static InvalidOperationException CreateExpectedNotNullOrAbsentException()
            =>
            new InvalidOperationException("The optional is expected to have a not null value or to be absent.");
    }
}
