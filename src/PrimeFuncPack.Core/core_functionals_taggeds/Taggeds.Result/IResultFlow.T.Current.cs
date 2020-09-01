#nullable enable

namespace System
{
    partial interface IResultFlow<TSuccess, TFailure>
    {
        public Result<TSuccess, TFailure> Current => CurrentOrigin;

        private protected Result<TSuccess, TFailure> CurrentOrigin { get; }
    }
}
