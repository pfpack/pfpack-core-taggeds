#nullable enable

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        public override string ToString()
            =>
            InternalFold(
                value => value?.ToString() ?? string.Empty,
                value => value?.ToString() ?? string.Empty,
                () => string.Empty);
    }
}
