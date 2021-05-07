#nullable enable

namespace System
{
    partial struct Optional<T>
    {
        public Optional(T value)
        {
            hasValue = true;
            this.value = value;
        }
    }
}
