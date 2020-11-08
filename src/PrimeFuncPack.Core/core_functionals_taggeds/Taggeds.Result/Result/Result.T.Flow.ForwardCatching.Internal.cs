#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct Result<TSuccess, TFailure>
    {
        private static Result<TNextSuccess, TFailure> InternalForwardSuccessCatching<TNextSuccess>(
            in TSuccess success,
            in Func<TSuccess, Result<TNextSuccess, TFailure>> nextFactory,
            in Func<Exception, TFailure> failureFactory)
            where TNextSuccess : notnull
        {
            try
            {
                return nextFactory.Invoke(success);
            }
            catch (Exception ex)
            {
                return failureFactory.Invoke(ex);
            }
        }

        private static Task<Result<TNextSuccess, TFailure>> InternalForwardSuccessCatchingAsync<TNextSuccess>(
            in TSuccess success,
            in Func<TSuccess, Task<Result<TNextSuccess, TFailure>>> nextFactoryAsync,
            in Func<Exception, TFailure> failureFactory)
            where TNextSuccess : notnull
        {
            try
            {
                return nextFactoryAsync.Invoke(success);
            }
            catch (Exception ex)
            {
                return Task.FromResult<Result<TNextSuccess, TFailure>>(failureFactory.Invoke(ex));
            }
        }

        private static ValueTask<Result<TNextSuccess, TFailure>> InternalForwardSuccessCatchingValueAsync<TNextSuccess>(
            in TSuccess success,
            in Func<TSuccess, ValueTask<Result<TNextSuccess, TFailure>>> nextFactoryAsync,
            in Func<Exception, TFailure> failureFactory)
            where TNextSuccess : notnull
        {
            try
            {
                return nextFactoryAsync.Invoke(success);
            }
            catch (Exception ex)
            {
                return ValueTask.FromResult<Result<TNextSuccess, TFailure>>(failureFactory.Invoke(ex));
            }
        }
    }
}
