#nullable enable

namespace System
{
    internal static class ObsoleteMessages
    {
        public const string PresentOrElse
            = "This method is not intended for use. Call Present and then FilterNotNull or FilterNotNullThenMap instead.";

        public const string PresentOrThrow
            = "This method is not intended for use. Call Present and then FilterNotNullOrThrow or FilterNotNullOrThrowThenMap instead.";
    }
}
