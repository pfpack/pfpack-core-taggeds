#nullable enable

namespace System
{
    partial struct Optional<T>
    {
        public Optional<T> OrAbsent() => Filter(value => value is object);
    }
}
