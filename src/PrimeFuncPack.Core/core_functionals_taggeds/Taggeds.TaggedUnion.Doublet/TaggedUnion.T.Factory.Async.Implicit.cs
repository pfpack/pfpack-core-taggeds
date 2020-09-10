#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        public static implicit operator Task<TaggedUnion<TFirst, TSecond>>(in TaggedUnion<TFirst, TSecond> union)
            =>
            union.ThisAsync();

        public static implicit operator ValueTask<TaggedUnion<TFirst, TSecond>>(in TaggedUnion<TFirst, TSecond> union)
            =>
            union.ThisValueAsync();
    }
}
