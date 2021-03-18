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
        {
            _ = exceptionFactory ?? throw new ArgumentNullException(nameof(exceptionFactory));

            return InternalOrThrow(exceptionFactory);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private T InternalOrThrow(Func<Exception> exceptionFactory)
            =>
            InternalHandleFold(Pipeline.Pipe, () => throw exceptionFactory.Invoke());
    }
}
