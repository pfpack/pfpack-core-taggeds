#nullable enable

using System.Runtime.CompilerServices;

namespace System
{
    partial struct Optional<T>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private T InternalOrThrow(Func<Exception> exceptionFactory)
            =>
            InternalFold(Pipeline.Pipe, () => throw exceptionFactory.Invoke());
    }
}
