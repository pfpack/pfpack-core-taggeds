namespace System;

partial struct Nonsuccess<TFailure>
{
    public static Nonsuccess<TFailure> Of(TFailure failure)
        =>
        new(failure);
}
