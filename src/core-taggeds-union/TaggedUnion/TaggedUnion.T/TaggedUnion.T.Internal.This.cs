#nullable enable

using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private TaggedUnion<TFirst, TSecond> This()
            =>
            this;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private Task<TaggedUnion<TFirst, TSecond>> ThisAsync()
            =>
            this.Pipe(Task.FromResult);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private ValueTask<TaggedUnion<TFirst, TSecond>> ThisValueAsync()
            =>
            this.Pipe(ValueTask.FromResult);
    }
}
