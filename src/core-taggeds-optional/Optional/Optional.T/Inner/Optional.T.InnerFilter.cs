using System.Threading.Tasks;

namespace System;

partial struct Optional<T>
{
    private Optional<T> InnerFilter(Func<T, bool> predicate)
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

    private async Task<Optional<T>> InnerFilterAsync(Func<T, Task<bool>> predicateAsync)
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

    private async ValueTask<Optional<T>> InnerFilterValueAsync(Func<T, ValueTask<bool>> predicateAsync)
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
