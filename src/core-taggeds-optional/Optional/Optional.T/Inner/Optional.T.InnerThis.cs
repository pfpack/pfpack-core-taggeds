using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace System
{
    partial struct Optional<T>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private Optional<T> InnerThis()
            =>
            this;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private Task<Optional<T>> InnerThisAsync()
            =>
            Task.FromResult<Optional<T>>(this);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private ValueTask<Optional<T>> InnerThisValueAsync()
            =>
            ValueTask.FromResult<Optional<T>>(this);
    }
}
