#nullable enable

using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace System
{
    partial struct Result<TSuccess, TFailure>
    {
        public TResult Fold<TResult>(
            Func<TSuccess, TResult> mapSuccess,
            Func<TFailure, TResult> mapFailure)
        {
            _ = mapSuccess ?? throw new ArgumentNullException(nameof(mapSuccess));
            _ = mapFailure ?? throw new ArgumentNullException(nameof(mapFailure));

            return Union.Fold(
                mapSuccess, mapFailure, Fold_OtherFactory_MustNeverBeInvoked<TResult>);
        }

        public Task<TResult> FoldAsync<TResult>(
            Func<TSuccess, Task<TResult>> mapSuccessAsync,
            Func<TFailure, Task<TResult>> mapFailureAsync)
        {
            _ = mapSuccessAsync ?? throw new ArgumentNullException(nameof(mapSuccessAsync));
            _ = mapFailureAsync ?? throw new ArgumentNullException(nameof(mapFailureAsync));

            return Union.FoldAsync(
                mapSuccessAsync, mapFailureAsync, Fold_OtherFactory_MustNeverBeInvoked<TResult>);
        }

        public ValueTask<TResult> FoldValueAsync<TResult>(
            Func<TSuccess, ValueTask<TResult>> mapSuccessAsync,
            Func<TFailure, ValueTask<TResult>> mapFailureAsync)
        {
            _ = mapSuccessAsync ?? throw new ArgumentNullException(nameof(mapSuccessAsync));
            _ = mapFailureAsync ?? throw new ArgumentNullException(nameof(mapFailureAsync));

            return Union.FoldValueAsync(
                mapSuccessAsync, mapFailureAsync, Fold_OtherFactory_MustNeverBeInvoked<TResult>);
        }

        [DoesNotReturn]
        private static TResult Fold_OtherFactory_MustNeverBeInvoked<TResult>()
            =>
            throw new InvalidOperationException("The result is not initialized.");
    }
}
