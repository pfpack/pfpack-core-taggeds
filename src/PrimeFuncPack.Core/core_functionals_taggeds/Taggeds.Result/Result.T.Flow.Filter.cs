#nullable enable

namespace System
{
    partial struct Result<TSuccess, TFailure>
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

            var @this = this;

            return Fold(Filter, failure => mapFailure.Invoke(failure));

            Result<TSuccess, TCauseFailure> Filter(TSuccess success) => predicate.Invoke(success) switch
            {
                true => @this.MapFailure(mapFailure),
                _ => causeFactory.Invoke(success)
            };
        }

        public Result<TSuccess, TFailure> Filter(
            Func<TSuccess, bool> predicate,
            Func<TSuccess, TFailure> causeFactory)
        {
            _ = predicate ?? throw new ArgumentNullException(nameof(predicate));
            _ = causeFactory ?? throw new ArgumentNullException(nameof(causeFactory));

            var @this = this;

            return Fold(Filter, _ => @this);

            Result<TSuccess, TFailure> Filter(TSuccess success) => predicate.Invoke(success) switch
            {
                true => @this,
                _ => causeFactory.Invoke(success)
            };
        }
    }
}
