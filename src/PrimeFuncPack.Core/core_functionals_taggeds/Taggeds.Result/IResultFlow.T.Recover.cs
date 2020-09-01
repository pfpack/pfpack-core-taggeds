#nullable enable

using static System.Result;

namespace System
{
    partial interface IResultFlow<TSuccess, TFailure>
    {
        public Result<TNextSuccess, TNextFailure> Recover<TNextSuccess, TNextFailure>(
            Func<TFailure, Result<TNextSuccess, TNextFailure>> nextFactory,
            Func<TSuccess, TNextSuccess> mapSuccess)
            where TNextSuccess : notnull
            where TNextFailure : notnull, new()
        {
            _ = nextFactory ?? throw new ArgumentNullException(nameof(nextFactory));
            _ = mapSuccess ?? throw new ArgumentNullException(nameof(mapSuccess));

            return Current.Fold(success => Success(mapSuccess.Invoke(success)), nextFactory);
        }

        public Result<TSuccess, TNextFailure> Recover<TNextFailure>(
            Func<TFailure, Result<TSuccess, TNextFailure>> nextFactory)
            where TNextFailure : notnull, new()
        {
            _ = nextFactory ?? throw new ArgumentNullException(nameof(nextFactory));

            return Current.Fold(success => Success(success), nextFactory);
        }

        public Result<TSuccess, TFailure> Recover(
            Func<TFailure, Result<TSuccess, TFailure>> nextFactory)
        {
            _ = nextFactory ?? throw new ArgumentNullException(nameof(nextFactory));

            return Current.Fold(_ => Current, nextFactory);
        }
    }
}
