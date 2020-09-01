#nullable enable

namespace System
{
    partial struct Result<TSuccess, TFailure>
    {
        Result<TSuccess, TFailure> IResultFlow<TSuccess, TFailure>.CurrentSource => this;
    }
}
