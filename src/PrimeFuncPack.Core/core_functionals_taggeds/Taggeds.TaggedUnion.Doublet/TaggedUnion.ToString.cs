#nullable enable

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        public override string ToString()
            =>
            ImplFold(
                value => value.ToStringOrEmpty(),
                value => value.ToStringOrEmpty())
            .OrElse(
                () => string.Empty);
    }
}
