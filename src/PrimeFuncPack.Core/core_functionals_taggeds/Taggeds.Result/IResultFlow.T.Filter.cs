#nullable enable

using static System.Result;

namespace System
{
    partial interface IResultFlow<TSuccess, TFailure>
    {
        public Result<TSuccess, TCauseFailure> Filter<TCauseFailure>(
            Func<TSuccess, bool> predicate,
            Func<TSuccess, TCauseFailure> causeFactory,
            Func<TFailure, TCauseFailure> mapFailure)
            where TCauseFailure : notnull, new()
        {
            _ = predicate ?? throw new ArgumentNullException(nameof(predicate));
            _ = causeFactory ?? throw new ArgumentNullException(nameof(causeFactory));
            _ = mapFailure ?? throw new ArgumentNullException(nameof(mapFailure));

            return Current.Fold(
                Filter,
                failure => Failure(mapFailure.Invoke(failure)));

            Result<TSuccess, TCauseFailure> Filter(TSuccess success) => predicate.Invoke(success) switch
            {
                true => Current.MapFailure(mapFailure),
                _ => Failure(causeFactory.Invoke(success))
            };
        }

        public Result<TSuccess, TFailure> Filter(
            Func<TSuccess, bool> predicate,
            Func<TSuccess, TFailure> causeFactory)
        {
            _ = predicate ?? throw new ArgumentNullException(nameof(predicate));
            _ = causeFactory ?? throw new ArgumentNullException(nameof(causeFactory));

            return Current.Fold(
                Filter,
                failure => Failure(failure));

            Result<TSuccess, TFailure> Filter(TSuccess success) => predicate.Invoke(success) switch
            {
                true => Current,
                _ => Failure(causeFactory.Invoke(success))
            };
        }
    }
}
