#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial class TaggedUnionExtensions
    {
        public static TaggedUnion<TFirst, TSecond> OrInitialize<TFirst, TSecond>(
            this TaggedUnion<TFirst, TSecond> union,
            Func<TaggedUnion<TFirst, TSecond>> otherFactory)
            =>
            union.InternalOrInitialize(
                Pipeline.Pipe,
                otherFactory ?? throw new ArgumentNullException(nameof(otherFactory)));

        public static Task<TaggedUnion<TFirst, TSecond>> OrInitializeAsync<TFirst, TSecond>(
            this TaggedUnion<TFirst, TSecond> union,
            Func<Task<TaggedUnion<TFirst, TSecond>>> otherFactoryAsync)
            =>
            union.InternalOrInitialize(
                Task.FromResult,
                otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync)));

        public static ValueTask<TaggedUnion<TFirst, TSecond>> OrInitializeValueAsync<TFirst, TSecond>(
            this TaggedUnion<TFirst, TSecond> union,
            Func<ValueTask<TaggedUnion<TFirst, TSecond>>> otherFactoryAsync)
            =>
            union.InternalOrInitialize(
                ValueTask.FromResult,
                otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync)));
    }
}
