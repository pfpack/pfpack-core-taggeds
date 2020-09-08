#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct Result<TSuccess, TFailure>
    {
        public static implicit operator Task<Result<TSuccess, TFailure>>(in Result<TSuccess, TFailure> result)
            =>
            result.ThisAsync();

        public static implicit operator ValueTask<Result<TSuccess, TFailure>>(in Result<TSuccess, TFailure> result)
            =>
            result.ThisValueAsync();
    }
}
