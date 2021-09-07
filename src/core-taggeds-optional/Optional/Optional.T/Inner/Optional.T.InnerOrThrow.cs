#nullable enable

using System.Runtime.CompilerServices;

namespace System
{
    partial struct Optional<T>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private T InnerOrThrow(Func<Exception> exceptionFactory)
            =>
            InnerFold(Pipeline.Pipe, () => throw exceptionFactory.Invoke());
    }
}
