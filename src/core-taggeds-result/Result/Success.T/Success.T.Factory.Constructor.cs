#pragma warning disable IDE0290 // Use primary constructor

namespace System;

partial struct Success<TSuccess>
{
    public Success(TSuccess success)
        =>
        this.success = success;
}
