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
            =>
            FoldSource.Fold(
                mapSuccess ?? throw new ArgumentNullException(nameof(mapSuccess)),
                mapFailure ?? throw new ArgumentNullException(nameof(mapFailure)),
                Fold_OtherFactory_MustNeverBeInvoked<TResult>);

        public Task<TResult> FoldAsync<TResult>(
            Func<TSuccess, Task<TResult>> mapSuccessAsync,
            Func<TFailure, Task<TResult>> mapFailureAsync)
            =>
            FoldSource.FoldAsync(
                mapSuccessAsync ?? throw new ArgumentNullException(nameof(mapSuccessAsync)),
                mapFailureAsync ?? throw new ArgumentNullException(nameof(mapFailureAsync)),
                Fold_OtherFactory_MustNeverBeInvoked<TResult>);

        public ValueTask<TResult> FoldValueAsync<TResult>(
            Func<TSuccess, ValueTask<TResult>> mapSuccessAsync,
            Func<TFailure, ValueTask<TResult>> mapFailureAsync)
            =>
            FoldSource.FoldValueAsync(
                mapSuccessAsync ?? throw new ArgumentNullException(nameof(mapSuccessAsync)),
                mapFailureAsync ?? throw new ArgumentNullException(nameof(mapFailureAsync)),
                Fold_OtherFactory_MustNeverBeInvoked<TResult>);

        private TaggedUnion<TSuccess, TFailure> FoldSource => union.OrFailure();

        [DoesNotReturn]
        private static TResult Fold_OtherFactory_MustNeverBeInvoked<TResult>()
            =>
            throw new InvalidOperationException("The result is not initialized.");
    }
}
