#nullable enable

namespace System
{
    partial struct Failure<TFailureCode>
    {
        private static class ObsoleteMessages
        {
            public const string Map = "This method is obsolete. Call MapFailureCode instead.";
        }
    }
}
