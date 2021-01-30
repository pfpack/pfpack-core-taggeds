#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct Result<TSuccess, TFailure>
    {
        public Result<TSuccess, TResultFailure> MapFailure<TResultFailure>(
            Func<TFailure, TResultFailure> mapFailure)
            where TResultFailure : struct
        {
            _ = mapFailure ?? throw new ArgumentNullException(nameof(mapFailure));
            return Union.MapSecond(mapFailure).AsResult();
        }

        public async Task<Result<TSuccess, TResultFailure>> MapFailureAsync<TResultFailure>(
            Func<TFailure, Task<TResultFailure>> mapFailureAsync)
            where TResultFailure : struct
        {
            _ = mapFailureAsync ?? throw new ArgumentNullException(nameof(mapFailureAsync));
            return (await Union.MapSecondAsync(mapFailureAsync).ConfigureAwait(false)).AsResult();
        }

        public async ValueTask<Result<TSuccess, TResultFailure>> MapFailureValueAsync<TResultFailure>(
            Func<TFailure, ValueTask<TResultFailure>> mapFailureAsync)
            where TResultFailure : struct
        {
            _ = mapFailureAsync ?? throw new ArgumentNullException(nameof(mapFailureAsync));
            return (await Union.MapSecondValueAsync(mapFailureAsync).ConfigureAwait(false)).AsResult();
        }
    }
}
