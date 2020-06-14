#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct Optional<T>
    {
        public T OrElse(in T other)
            =>
            box switch
            {
                null => other,
                var present => present
            };

        public T OrElse(in Func<T> otherFactory)
            =>
            box switch
            {
                null => otherFactory.Invoke(),
                var present => present
            };

        public Task<T> OrElseAsync(in Func<Task<T>> otherFactory)
            =>
            box switch
            {
                null => otherFactory.Invoke(),
                var present => Task.FromResult<T>(present)
            };
    }
}
