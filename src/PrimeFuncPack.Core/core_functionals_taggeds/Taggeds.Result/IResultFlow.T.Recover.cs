#nullable enable

using static System.Result;

namespace System
{
    partial interface IResultFlow<TSuccess, TFailure>
    {
        public Result<TNextSuccess, TNextFailure> Recover<TNextSuccess, TNextFailure>(
            Func<TFailure, Result<TNextSuccess, TNextFailure>> otherFactory,
            Func<TSuccess, TNextSuccess> mapSuccess)
            where TNextSuccess : notnull
            where TNextFailure : notnull, new()
        {
            _ = otherFactory ?? throw new ArgumentNullException(nameof(otherFactory));
            _ = mapSuccess ?? throw new ArgumentNullException(nameof(mapSuccess));

            return Current.Fold(success => Success(mapSuccess.Invoke(success)), otherFactory);
        }

        public Result<TSuccess, TNextFailure> Recover<TNextFailure>(
            Func<TFailure, Result<TSuccess, TNextFailure>> otherFactory)
            where TNextFailure : notnull, new()
        {
            _ = otherFactory ?? throw new ArgumentNullException(nameof(otherFactory));

            return Current.Fold(success => Success(success), otherFactory);
        }

        public Result<TSuccess, TFailure> Recover(
            Func<TFailure, Result<TSuccess, TFailure>> otherFactory)
        {
            _ = otherFactory ?? throw new ArgumentNullException(nameof(otherFactory));

            return Current.Fold(_ => Current, otherFactory);
        }
    }
}
