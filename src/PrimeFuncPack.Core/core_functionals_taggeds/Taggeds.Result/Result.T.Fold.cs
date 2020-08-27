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
                AssertInitialized<TResult>);

        public Task<TResult> FoldAsync<TResult>(
            Func<TSuccess, Task<TResult>> mapSuccessAsync,
            Func<TFailure, Task<TResult>> mapFailureAsync)
            =>
            FoldSource.FoldAsync(
                mapSuccessAsync ?? throw new ArgumentNullException(nameof(mapSuccessAsync)),
                mapFailureAsync ?? throw new ArgumentNullException(nameof(mapFailureAsync)),
                AssertInitialized<TResult>);

        public ValueTask<TResult> FoldAsync<TResult>(
            Func<TSuccess, ValueTask<TResult>> mapSuccessAsync,
            Func<TFailure, ValueTask<TResult>> mapFailureAsync)
            =>
            FoldSource.FoldAsync(
                mapSuccessAsync ?? throw new ArgumentNullException(nameof(mapSuccessAsync)),
                mapFailureAsync ?? throw new ArgumentNullException(nameof(mapFailureAsync)),
                AssertInitialized<TResult>);

        private TaggedUnion<TSuccess, TFailure> FoldSource => union.OrFailure();

        // Must never throw
        [DoesNotReturn]
        private static TResult AssertInitialized<TResult>()
            =>
            throw new InvalidOperationException("The result is not initialized.");
    }
}
