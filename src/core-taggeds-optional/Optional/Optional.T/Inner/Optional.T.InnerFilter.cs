using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace System;

partial struct Optional<T>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private Optional<T> InnerFilter(
        Func<T, bool> predicate)
    {
        if (hasValue is false)
        {
            return this;
        }

        if (predicate.Invoke(value))
        {
            return this;
        }

        return default;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private async Task<Optional<T>> InnerFilterAsync(
        Func<T, Task<bool>> predicateAsync)
    {
        if (hasValue is false)
        {
            return this;
        }

        if (await predicateAsync.Invoke(value).ConfigureAwait(false))
        {
            return this;
        }

        return default;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private async ValueTask<Optional<T>> InnerFilterValueAsync(
        Func<T, ValueTask<bool>> predicateAsync)
    {
        if (hasValue is false)
        {
            return this;
        }

        if (await predicateAsync.Invoke(value).ConfigureAwait(false))
        {
            return this;
        }

        return default;
    }
}
