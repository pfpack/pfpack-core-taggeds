#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        public Task<TaggedUnion<TFirst, TSecond>> ThisAsync()
            =>
            Task.FromResult(this);

        public ValueTask<TaggedUnion<TFirst, TSecond>> ThisValueAsync()
            =>
            ValueTask.FromResult(this);
    }
}
