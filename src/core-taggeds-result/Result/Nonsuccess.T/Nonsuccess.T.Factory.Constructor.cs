namespace System;

partial struct Nonsuccess<TFailure>
{
    public Nonsuccess(TFailure failure)
        =>
        this.failure = failure;
}
