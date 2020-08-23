#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        public TaggedUnion<TFirst, TSecond> Or(Func<TaggedUnion<TFirst, TSecond>> otherFactory)
            =>
            ImplFold(Pipeline.Pipe, otherFactory);

        public Task<TaggedUnion<TFirst, TSecond>> OrAsync(Func<Task<TaggedUnion<TFirst, TSecond>>> otherFactoryAsync)
            =>
            ImplFold(Task.FromResult, otherFactoryAsync);

        public ValueTask<TaggedUnion<TFirst, TSecond>> OrAsync(Func<ValueTask<TaggedUnion<TFirst, TSecond>>> otherFactoryAsync)
            =>
            ImplFold(ValueTask.FromResult, otherFactoryAsync);
    }
}
