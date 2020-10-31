#nullable enable

namespace System
{
    partial class OptionalResultExtensions
    {
        private static class ObsoleteMessages
        {
            public const string ToResult
                = "This method is not intended for use. Call ToResultOrThrowOnNull or ToResultOrFailureOnNull instead.";
        }
    }
}
