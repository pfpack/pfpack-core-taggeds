#nullable enable

namespace PrimeFuncPack
{
    partial struct Optional<T>
    {
        public Optional<object?> Box() => Map<object?>(value => value);
    }
}
