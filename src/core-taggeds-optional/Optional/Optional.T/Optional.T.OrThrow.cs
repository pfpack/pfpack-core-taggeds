#nullable enable

using System.Runtime.CompilerServices;

namespace System
{
    partial struct Optional<T>
    {
        public T OrThrow()
            =>
            InternalOrThrow(CreateExpectedPresentException);

        public T OrThrow(Func<Exception> exceptionFactory)
            =>
            InternalOrThrow(exceptionFactory ?? throw new ArgumentNullException(nameof(exceptionFactory)));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private T InternalOrThrow(Func<Exception> exceptionFactory)
            =>
            InternalFold(Pipeline.Pipe, () => throw exceptionFactory.Invoke());
    }
}
