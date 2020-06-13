#nullable enable

namespace System
{
    partial struct Optional<T>
    {
        public Optional<object?> Box() => Map<object?>(value => value);
    }
}
