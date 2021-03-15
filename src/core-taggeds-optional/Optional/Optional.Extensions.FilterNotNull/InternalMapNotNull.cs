#nullable enable

using System.Runtime.CompilerServices;

namespace System
{
    partial class FilterNotNullOptionalExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static T InternalMapToNonNullable<T>(T? value)
            =>
            value ?? throw CreateUnexpectedNullException_MustNeverBeInvoked();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static T InternalMapToNonNullable<T>(T? value) where T : struct
            =>
            value ?? throw CreateUnexpectedNullException_MustNeverBeInvoked();
    }
}
