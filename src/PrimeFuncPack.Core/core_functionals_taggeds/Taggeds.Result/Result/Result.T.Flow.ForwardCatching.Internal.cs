#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct Result<TSuccess, TFailure>
    {
        private static Result<TNextSuccess, TNextFailure> InternalNextFactoryCatching<TNextSuccess, TNextFailure>(
            TSuccess success,
            Func<TSuccess, Result<TNextSuccess, TNextFailure>> nextFactory,
            Func<Exception, TNextFailure> failureFactory)
            where TNextSuccess : notnull
            where TNextFailure : struct
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

        private static Task<Result<TNextSuccess, TNextFailure>> InternalNextFactoryCatchingAsync<TNextSuccess, TNextFailure>(
            TSuccess success,
            Func<TSuccess, Task<Result<TNextSuccess, TNextFailure>>> nextFactoryAsync,
            Func<Exception, TNextFailure> failureFactory)
            where TNextSuccess : notnull
            where TNextFailure : struct
        {
            try
            {
                return nextFactoryAsync.Invoke(success);
            }
            catch (Exception ex)
            {
                return Task.FromResult<Result<TNextSuccess, TNextFailure>>(failureFactory.Invoke(ex));
            }
        }

        private static ValueTask<Result<TNextSuccess, TNextFailure>> InternalNextFactoryCatchingValueAsync<TNextSuccess, TNextFailure>(
            TSuccess success,
            Func<TSuccess, ValueTask<Result<TNextSuccess, TNextFailure>>> nextFactoryAsync,
            Func<Exception, TNextFailure> failureFactory)
            where TNextSuccess : notnull
            where TNextFailure : struct
        {
            try
            {
                return nextFactoryAsync.Invoke(success);
            }
            catch (Exception ex)
            {
                return ValueTask.FromResult<Result<TNextSuccess, TNextFailure>>(failureFactory.Invoke(ex));
            }
        }
    }
}
