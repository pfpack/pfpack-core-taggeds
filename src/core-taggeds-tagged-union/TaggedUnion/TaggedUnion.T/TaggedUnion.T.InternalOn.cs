#nullable enable

using System.Runtime.CompilerServices;

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private TResult InternalOn<TOnFirstOut, TOnSecondOut, TResult>(
            Func<TFirst, TOnFirstOut> onFirst,
            Func<TSecond, TOnSecondOut> onSecond,
            Func<TResult> resultSupplier)
        {
            if (tag == Tag.First)
            {
                _ = onFirst.Invoke(first);
            }
            else if (tag == Tag.Second)
            {
                _ = onSecond.Invoke(second);
            }

            return resultSupplier.Invoke();
        }
    }
}
