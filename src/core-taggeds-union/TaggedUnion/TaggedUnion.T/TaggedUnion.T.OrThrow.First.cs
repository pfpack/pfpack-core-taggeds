namespace System;

partial struct TaggedUnion<TFirst, TSecond>
{
    public TFirst FirstOrThrow()
        =>
        InnerFirstOrThrow(InnerCreateExpectedFirstException);

    public TFirst FirstOrThrow(Func<Exception> exceptionFactory)
        =>
        InnerFirstOrThrow(exceptionFactory ?? throw new ArgumentNullException(nameof(exceptionFactory)));
}
