#nullable enable

namespace System
{
    public partial interface IResultFlow<TSuccess, TFailure>
        where TSuccess : notnull
        where TFailure : notnull, new()
    {
    }
}
