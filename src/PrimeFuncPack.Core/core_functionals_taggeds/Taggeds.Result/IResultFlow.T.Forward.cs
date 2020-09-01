#nullable enable

using static System.Result;

namespace System
{
    partial interface IResultFlow<TSuccess, TFailure>
    {
        public Result<TNextSuccess, TNextFailure> Forward<TNextSuccess, TNextFailure>(
            Func<TSuccess, Result<TNextSuccess, TNextFailure>> nextFactory,
            Func<TFailure, TNextFailure> mapFailure)
            where TNextSuccess : notnull
            where TNextFailure : notnull, new()
        {
            _ = nextFactory ?? throw new ArgumentNullException(nameof(nextFactory));
            _ = mapFailure ?? throw new ArgumentNullException(nameof(mapFailure));

            return Current.Fold(nextFactory, failure => Failure(mapFailure.Invoke(failure)));
        }

        public Result<TNextSuccess, TFailure> Forward<TNextSuccess>(
            Func<TSuccess, Result<TNextSuccess, TFailure>> nextFactory)
            where TNextSuccess : notnull
        {
            _ = nextFactory ?? throw new ArgumentNullException(nameof(nextFactory));

            return Current.Fold(nextFactory, failure => Failure(failure));
        }

        public Result<TSuccess, TFailure> Forward(
            Func<TSuccess, Result<TSuccess, TFailure>> nextFactory)
        {
            _ = nextFactory ?? throw new ArgumentNullException(nameof(nextFactory));

            return Current.Fold(nextFactory, _ => Current);
        }
    }
}
