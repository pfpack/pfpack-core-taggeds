#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct Result<TSuccess, TFailure>
    {
        public Task<Result<TSuccess, TFailure>> ThisAsync()
            =>
            Task.FromResult(this);

        public ValueTask<Result<TSuccess, TFailure>> ThisValueAsync()
            =>
            ValueTask.FromResult(this);
    }
}
