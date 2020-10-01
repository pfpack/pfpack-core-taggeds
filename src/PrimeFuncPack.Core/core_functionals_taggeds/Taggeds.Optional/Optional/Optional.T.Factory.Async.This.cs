#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct Optional<T>
    {
        public Task<Optional<T>> ThisAsync()
            =>
            Task.FromResult(this);

        public ValueTask<Optional<T>> ThisValueAsync()
            =>
            ValueTask.FromResult(this);
    }
}
