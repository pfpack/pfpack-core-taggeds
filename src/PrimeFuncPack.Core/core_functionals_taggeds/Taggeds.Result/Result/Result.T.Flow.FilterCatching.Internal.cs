#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct Result<TSuccess, TFailure>
    {
        private static Result<TSuccess, TFailure> InternalFilterSuccessCatching(
            in TSuccess success,
            in Func<TSuccess, TFailure> causeFactory,
            in Func<Exception, TFailure> failureFactory)
        {
            try
            {
                return causeFactory.Invoke(success);
            }
            catch (Exception ex)
            {
                return failureFactory.Invoke(ex);
            }
        }

        private static async Task<Result<TSuccess, TFailure>> InternalFilterSuccessCatchingAsync(
            TSuccess success,
            Func<TSuccess, Task<TFailure>> causeFactoryAsync,
            Func<Exception, TFailure> failureFactory)
        {
            try
            {
                return await causeFactoryAsync.Invoke(success).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                return failureFactory.Invoke(ex);
            }
        }

        private static async ValueTask<Result<TSuccess, TFailure>> InternalFilterSuccessCatchingValueAsync(
            TSuccess success,
            Func<TSuccess, ValueTask<TFailure>> causeFactoryAsync,
            Func<Exception, TFailure> failureFactory)
        {
            try
            {
                return await causeFactoryAsync.Invoke(success).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                return failureFactory.Invoke(ex);
            }
        }
    }
}
