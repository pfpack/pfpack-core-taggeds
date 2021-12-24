namespace System;

partial struct TaggedUnion<TFirst, TSecond>
{
    public TSecond SecondOrThrow()
        =>
        InnerSecondOrThrow(InnerCreateExpectedSecondException);

    public TSecond SecondOrThrow(Func<Exception> exceptionFactory)
        =>
        InnerSecondOrThrow(exceptionFactory ?? throw new ArgumentNullException(nameof(exceptionFactory)));
}
