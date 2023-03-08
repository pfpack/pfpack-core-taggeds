namespace System;

partial struct Success<TSuccess>
{
    public Success(TSuccess success)
        =>
        this.success = success;
}
