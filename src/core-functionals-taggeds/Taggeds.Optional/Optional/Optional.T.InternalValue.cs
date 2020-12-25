#nullable enable

namespace System
{
    partial struct Optional<T>
    {
        private T InternalValue() => value;
    }
}
