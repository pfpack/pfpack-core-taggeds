#nullable enable

using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace System
{
    partial struct Optional<T>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private Optional<T> This()
            =>
            this;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private Task<Optional<T>> ThisAsync()
            =>
            Task.FromResult(this);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private ValueTask<Optional<T>> ThisValueAsync()
            =>
            ValueTask.FromResult(this);
    }
}
