#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct TaggedUnion<TTag, TFirst, TSecond>
    {
        public TResult Fold<TResult>(
            in Func<TFirst, TResult> mapFirst,
            in Func<TSecond, TResult> mapSecond)
            =>
            (boxFirst, boxSecond) switch
            {
                (Box<TFirst> first, _) => mapFirst(first),
                (_, Box<TSecond> second) => mapSecond(second),
                _ => throw CreateNotInitializedException()
            };

        public Task<TResult> FoldAsync<TResult>(
            in Func<TFirst, Task<TResult>> mapFirst,
            in Func<TSecond, Task<TResult>> mapSecond)
            =>
            (boxFirst, boxSecond) switch
            {
                (Box<TFirst> first, _) => mapFirst(first),
                (_, Box<TSecond> second) => mapSecond(second),
                _ => throw CreateNotInitializedException()
            };
    }
}
