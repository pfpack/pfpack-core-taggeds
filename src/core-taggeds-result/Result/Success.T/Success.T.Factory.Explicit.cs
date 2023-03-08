namespace System;

partial struct Success<TSuccess>
{
    public static Success<TSuccess> Of(TSuccess success)
        =>
        new(success);
}
