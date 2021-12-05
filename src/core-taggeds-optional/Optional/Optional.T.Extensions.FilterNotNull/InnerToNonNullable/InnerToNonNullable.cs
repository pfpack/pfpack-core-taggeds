using System.Runtime.CompilerServices;

namespace System;

partial class FilterNotNullOptionalExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static T InnerToNonNullable<T>(T? value)
        =>
        value is not null
            ? value
            : throw InnerCreateUnexpectedNullException_MustNeverBeInvoked();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static T InnerToNonNullable<T>(T? value)
        where T : struct
        =>
        value is not null
            ? value.GetValueOrDefault()
            : throw InnerCreateUnexpectedNullException_MustNeverBeInvoked();

    private static InvalidOperationException InnerCreateUnexpectedNullException_MustNeverBeInvoked()
        =>
        new("The optional has unexpected null value.");
}
