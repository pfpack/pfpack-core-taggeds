#nullable enable

using static System.Strings;

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        public override string ToString()
            =>
            Fold(ToStringOrEmpty, ToStringOrEmpty, GetEmpty);
    }
}
