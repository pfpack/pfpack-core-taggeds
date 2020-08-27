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
                AssertInited<TResult>);

        public Task<TResult> FoldAsync<TResult>(
            Func<TSuccess, Task<TResult>> mapSuccessAsync,
            Func<TFailure, Task<TResult>> mapFailureAsync)
            =>
            FoldSource.FoldAsync(
                mapSuccessAsync ?? throw new ArgumentNullException(nameof(mapSuccessAsync)),
                mapFailureAsync ?? throw new ArgumentNullException(nameof(mapFailureAsync)),
                AssertInited<TResult>);

        public ValueTask<TResult> FoldAsync<TResult>(
            Func<TSuccess, ValueTask<TResult>> mapSuccessAsync,
            Func<TFailure, ValueTask<TResult>> mapFailureAsync)
            =>
            FoldSource.FoldAsync(
                mapSuccessAsync ?? throw new ArgumentNullException(nameof(mapSuccessAsync)),
                mapFailureAsync ?? throw new ArgumentNullException(nameof(mapFailureAsync)),
                AssertInited<TResult>);

        private TaggedUnion<TSuccess, TFailure> FoldSource => union.OrInited();

        // Must never throw
        [DoesNotReturn]
        private static TResult AssertInited<TResult>()
            =>
            throw new InvalidOperationException("The result is not initialized.");
    }
}
