#nullable enable

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        private TaggedUnion<TFirst, TSecond> UnitToThis(Unit unit) => unit.ToResult(this);
    }
}
