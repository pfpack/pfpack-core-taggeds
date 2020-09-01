#nullable enable

namespace System
{
    partial interface IResultFlow<TSuccess, TFailure>
    {
        public Result<TSuccess, TFailure> Current => CurrentSource;

        private protected Result<TSuccess, TFailure> CurrentSource { get; }
    }
}
