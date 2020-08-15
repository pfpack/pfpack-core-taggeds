#nullable enable

namespace System
{
    partial struct Optional<T>
    {
        public override string ToString()
            =>
            ImplFold(value => value.ToStringOrEmpty(), () => string.Empty);
    }
}
