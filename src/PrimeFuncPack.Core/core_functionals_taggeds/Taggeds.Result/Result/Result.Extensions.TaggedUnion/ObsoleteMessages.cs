﻿#nullable enable

namespace System
{
    partial class TaggedUnionResultExtensions
    {
        private static class ObsoleteMessages
        {
            public const string ToResult
                = "This method is not intended for use. Call "
                + nameof(ToResultOrThrowOnNull)
                + " or "
                + nameof(ToResultOrFailureOnNull)
                + " instead.";
        }
    }
}
