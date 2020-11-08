#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct Result<TSuccess, TFailure>
    {
        private static Result<TSuccess, TOtherFailure> InternalRecoverFailureCatching<TOtherFailure>(
            in TFailure failure,
            in Func<TFailure, Result<TSuccess, TOtherFailure>> otherFactory,
            in Func<Exception, TOtherFailure> failureFactory)
            where TOtherFailure : struct
        {
            try
            {
                return otherFactory.Invoke(failure);
            }
            catch (Exception ex)
            {
                return failureFactory.Invoke(ex);
            }
        }

        private static Task<Result<TSuccess, TOtherFailure>> InternalRecoverFailureCatchingAsync<TOtherFailure>(
            in TFailure failure,
            in Func<TFailure, Task<Result<TSuccess, TOtherFailure>>> otherFactoryAsync,
            in Func<Exception, TOtherFailure> failureFactory)
            where TOtherFailure : struct
        {
            try
            {
                return otherFactoryAsync.Invoke(failure);
            }
            catch (Exception ex)
            {
                return Task.FromResult<Result<TSuccess, TOtherFailure>>(failureFactory.Invoke(ex));
            }
        }

        private static ValueTask<Result<TSuccess, TOtherFailure>> InternalRecoverFailureCatchingValueAsync<TOtherFailure>(
            in TFailure failure,
            in Func<TFailure, ValueTask<Result<TSuccess, TOtherFailure>>> otherFactoryAsync,
            in Func<Exception, TOtherFailure> failureFactory)
            where TOtherFailure : struct
        {
            try
            {
                return otherFactoryAsync.Invoke(failure);
            }
            catch (Exception ex)
            {
                return ValueTask.FromResult<Result<TSuccess, TOtherFailure>>(failureFactory.Invoke(ex));
            }
        }
    }
}
