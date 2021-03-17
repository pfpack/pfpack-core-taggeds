#nullable enable

using System.Runtime.CompilerServices;

namespace System
{
    partial class FilterNotNullOptionalExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static T InternalToNonNullable<T>(T? value)
            =>
            value is not null
                ? value
                : throw CreateUnexpectedNullException_MustNeverBeInvoked();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static T InternalToNonNullable<T>(T? value)
            where T : struct
            =>
            value is not null
                ? value.GetValueOrDefault()
                : throw CreateUnexpectedNullException_MustNeverBeInvoked();
    }
}
