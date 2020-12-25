#nullable enable

namespace System
{
    partial struct Optional<T>
    {
        private Optional<T> InternalThis() => this;
    }
}
