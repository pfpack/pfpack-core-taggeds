#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        public TaggedUnion<TFirst, TSecond> Or(Func<TaggedUnion<TFirst, TSecond>> otherFactory)
            =>
            InternalOr(
                Pipeline.Pipe,
                otherFactory ?? throw new ArgumentNullException(nameof(otherFactory)));

        public Task<TaggedUnion<TFirst, TSecond>> OrAsync(Func<Task<TaggedUnion<TFirst, TSecond>>> otherFactoryAsync)
            =>
            InternalOr(
                Task.FromResult,
                otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync)));

        public ValueTask<TaggedUnion<TFirst, TSecond>> OrValueAsync(Func<ValueTask<TaggedUnion<TFirst, TSecond>>> otherFactoryAsync)
            =>
            InternalOr(
                ValueTask.FromResult,
                otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync)));
    }
}
