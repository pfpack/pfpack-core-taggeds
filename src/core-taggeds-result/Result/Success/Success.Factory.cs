namespace System;

partial class Success
{
    public static Success<TSuccess> Of<TSuccess>(TSuccess success)
        =>
        new(success);
}
