#pragma warning disable IDE0290 // Use primary constructor

namespace System;

partial struct Nonsuccess<TFailure>
{
    public Nonsuccess(TFailure failure)
        =>
        this.failure = failure;
}
