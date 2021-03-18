#nullable enable

namespace System
{
    partial struct Result<TSuccess, TFailure>
    {
        private static Type EqualityContract => typeof(Result<TSuccess, TFailure>);
    }
}
