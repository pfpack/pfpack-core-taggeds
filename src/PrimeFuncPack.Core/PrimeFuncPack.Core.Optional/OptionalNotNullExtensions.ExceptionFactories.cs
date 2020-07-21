#nullable enable

namespace System
{
    partial class OptionalNotNullExtensions
    {
        private static InvalidOperationException CreateNoNotnullPresentException()
            =>
            new InvalidOperationException("The optional does not have a not null present value.");

        private static InvalidOperationException CreateNoNotnullPresentOrAbsentException()
            =>
            new InvalidOperationException("The optional does not have a not null present or the absent value.");
    }
}
