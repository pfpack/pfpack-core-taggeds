#nullable enable

namespace System
{
    partial struct Optional<T>
    {
        public Optional<T> OrAbsent() => Filter(predicate: value => value is object);
    }
}
