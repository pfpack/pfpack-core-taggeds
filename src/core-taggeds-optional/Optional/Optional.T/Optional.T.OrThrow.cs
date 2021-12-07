namespace System;

partial struct Optional<T>
{
    public T OrThrow()
        =>
        InnerOrThrow(() => new InvalidOperationException("The optional is expected to have a value."));

    public T OrThrow(Func<Exception> exceptionFactory)
        =>
        InnerOrThrow(exceptionFactory ?? throw new ArgumentNullException(nameof(exceptionFactory)));
}
