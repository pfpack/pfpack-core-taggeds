#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct Result<TSuccess, TFailure>
    {
        public Result<TResultSuccess, TFailure> MapSuccess<TResultSuccess>(
            Func<TSuccess, TResultSuccess> mapSuccess)
        {
            _ = mapSuccess ?? throw new ArgumentNullException(nameof(mapSuccess));

            return Union.MapFirst(mapSuccess).AsResult();
        }

        public async Task<Result<TResultSuccess, TFailure>> MapSuccessAsync<TResultSuccess>(
            Func<TSuccess, Task<TResultSuccess>> mapSuccessAsync)
        {
            _ = mapSuccessAsync ?? throw new ArgumentNullException(nameof(mapSuccessAsync));

            return (await Union.MapFirstAsync(mapSuccessAsync).ConfigureAwait(false)).AsResult();
        }

        public async ValueTask<Result<TResultSuccess, TFailure>> MapSuccessValueAsync<TResultSuccess>(
            Func<TSuccess, ValueTask<TResultSuccess>> mapSuccessAsync)
        {
            _ = mapSuccessAsync ?? throw new ArgumentNullException(nameof(mapSuccessAsync));
            
            return (await Union.MapFirstValueAsync(mapSuccessAsync).ConfigureAwait(false)).AsResult();
        }
    }
}
