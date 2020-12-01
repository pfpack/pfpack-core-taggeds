#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct Result<TSuccess, TFailure>
    {
        // Map

        public Result<TResultSuccess, TFailure> MapSuccess<TResultSuccess>(
            Func<TSuccess, TResultSuccess> mapSuccess)
            where TResultSuccess : notnull
            =>
            Union.MapFirst(mapSuccess).AsResult();

        public Result<TSuccess, TResultFailure> MapFailure<TResultFailure>(
            Func<TFailure, TResultFailure> mapFailure)
            where TResultFailure : struct
            =>
            Union.MapSecond(mapFailure).AsResult();

        public Result<TResultSuccess, TResultFailure> Map<TResultSuccess, TResultFailure>(
            Func<TSuccess, TResultSuccess> mapSuccess,
            Func<TFailure, TResultFailure> mapFailure)
            where TResultSuccess : notnull
            where TResultFailure : struct
            =>
            Union.Map(mapSuccess, mapFailure).AsResult();

        // Map Async / Task

        public async Task<Result<TResultSuccess, TFailure>> MapSuccessAsync<TResultSuccess>(
            Func<TSuccess, Task<TResultSuccess>> mapSuccessAsync)
            where TResultSuccess : notnull
            =>
            (await Union.MapFirstAsync(mapSuccessAsync).ConfigureAwait(false)).AsResult();

        public async Task<Result<TSuccess, TResultFailure>> MapFailureAsync<TResultFailure>(
            Func<TFailure, Task<TResultFailure>> mapFailureAsync)
            where TResultFailure : struct
            =>
            (await Union.MapSecondAsync(mapFailureAsync).ConfigureAwait(false)).AsResult();

        public async Task<Result<TResultSuccess, TResultFailure>> MapAsync<TResultSuccess, TResultFailure>(
            Func<TSuccess, Task<TResultSuccess>> mapSuccessAsync,
            Func<TFailure, Task<TResultFailure>> mapFailureAsync)
            where TResultSuccess : notnull
            where TResultFailure : struct
            =>
            (await Union.MapAsync(mapSuccessAsync, mapFailureAsync).ConfigureAwait(false)).AsResult();

        // Map Async / ValueTask

        public async ValueTask<Result<TResultSuccess, TFailure>> MapSuccessValueAsync<TResultSuccess>(
            Func<TSuccess, ValueTask<TResultSuccess>> mapSuccessAsync)
            where TResultSuccess : notnull
            =>
            (await Union.MapFirstValueAsync(mapSuccessAsync).ConfigureAwait(false)).AsResult();

        public async ValueTask<Result<TSuccess, TResultFailure>> MapFailureValueAsync<TResultFailure>(
            Func<TFailure, ValueTask<TResultFailure>> mapFailureAsync)
            where TResultFailure : struct
            =>
            (await Union.MapSecondValueAsync(mapFailureAsync).ConfigureAwait(false)).AsResult();

        public async ValueTask<Result<TResultSuccess, TResultFailure>> MapValueAsync<TResultSuccess, TResultFailure>(
            Func<TSuccess, ValueTask<TResultSuccess>> mapSuccessAsync,
            Func<TFailure, ValueTask<TResultFailure>> mapFailureAsync)
            where TResultSuccess : notnull
            where TResultFailure : struct
            =>
            (await Union.MapValueAsync(mapSuccessAsync, mapFailureAsync).ConfigureAwait(false)).AsResult();
    }
}
