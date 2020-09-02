#nullable enable

using static System.Result;

namespace System
{
    partial interface IResultFlow<TSuccess, TFailure>
    {
        public Result<TSuccess, TNextFailure> Filter<TNextFailure>(
            Func<TSuccess, bool> predicate,
            Func<TSuccess, TNextFailure> failureFactory,
            Func<TFailure, TNextFailure> mapFailure)
            where TNextFailure : notnull, new()
        {
            _ = predicate ?? throw new ArgumentNullException(nameof(predicate));
            _ = failureFactory ?? throw new ArgumentNullException(nameof(failureFactory));
            _ = mapFailure ?? throw new ArgumentNullException(nameof(mapFailure));

            return Current.Fold(
                Filter,
                failure => Failure(mapFailure.Invoke(failure)));

            Result<TSuccess, TNextFailure> Filter(TSuccess success) => predicate.Invoke(success) switch
            {
                true => Current.MapFailure(mapFailure),
                _ => Failure(failureFactory.Invoke(success))
            };
        }

        public Result<TSuccess, TFailure> Filter(
            Func<TSuccess, bool> predicate,
            Func<TSuccess, TFailure> failureFactory)
        {
            _ = predicate ?? throw new ArgumentNullException(nameof(predicate));
            _ = failureFactory ?? throw new ArgumentNullException(nameof(failureFactory));

            return Current.Fold(
                Filter,
                failure => Failure(failure));

            Result<TSuccess, TFailure> Filter(TSuccess success) => predicate.Invoke(success) switch
            {
                true => Current,
                _ => Failure(failureFactory.Invoke(success))
            };
        }
    }
}
