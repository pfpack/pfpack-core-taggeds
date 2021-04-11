#nullable enable

using System.Runtime.CompilerServices;

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private TResult InternalFold<TResult>(
            Func<TFirst, TResult> mapFirst,
            Func<TSecond, TResult> mapSecond,
            Func<TResult> otherFactory)
        {
            if (tag == Tag.First)
            {
                return mapFirst.Invoke(first);
            }

            if (tag == Tag.Second)
            {
                return mapSecond.Invoke(second);
            }

            return otherFactory.Invoke();
        }
    }
}
