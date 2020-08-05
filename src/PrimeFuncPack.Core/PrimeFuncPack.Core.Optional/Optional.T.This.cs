#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct Optional<T>
    {
        private Optional<T> This() => this;

        private Task<Optional<T>> ThisAsync() => Task.FromResult(this);
    }
}
