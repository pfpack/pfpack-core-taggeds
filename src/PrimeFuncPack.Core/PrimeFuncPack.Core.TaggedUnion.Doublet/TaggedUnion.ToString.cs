#nullable enable

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        public override string ToString() => ImplFoldOrElse(
            value => value.ToStringOrEmpty(),
            value => value.ToStringOrEmpty(),
            () => string.Empty);
    }
}
