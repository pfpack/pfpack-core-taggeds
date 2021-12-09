namespace System;

partial struct TaggedUnion<TFirst, TSecond>
{
    public TFirst FirstOrThrow()
        =>
        InternalFirstOrThrow(CreateNotFirstException);

    public TFirst FirstOrThrow(Func<Exception> exceptionFactory)
    {
        _ = exceptionFactory ?? throw new ArgumentNullException(nameof(exceptionFactory));
            
        return InternalFirstOrThrow(exceptionFactory);
    }
}
