#nullable enable

namespace System
{
    partial class OptionalNotNullExtensions
    {
        private static InvalidOperationException CreatePresentAndNullException()
            =>
            new InvalidOperationException("The optional has a present value and the value is null.");
    }
}
