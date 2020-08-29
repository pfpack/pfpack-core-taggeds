#nullable enable

using static System.Result;

namespace System
{
    partial interface IResultFlow<TSuccess, TFailure>
    {
        public Result<TNextSuccess, TNextFailure> Next<TNextSuccess, TNextFailure>(
            Func<TSuccess, Result<TNextSuccess, TNextFailure>> getNext,
            Func<TFailure, TNextFailure> mapFailure)
            where TNextSuccess : notnull
            where TNextFailure : notnull, new()
        {
            _ = getNext ?? throw new ArgumentNullException(nameof(getNext));
            _ = mapFailure ?? throw new ArgumentNullException(nameof(mapFailure));

            return Current.Fold(getNext, failure => Failure(mapFailure.Invoke(failure)));
        }

        public Result<TNextSuccess, TFailure> Next<TNextSuccess>(
            Func<TSuccess, Result<TNextSuccess, TFailure>> getNext)
            where TNextSuccess : notnull
        {
            _ = getNext ?? throw new ArgumentNullException(nameof(getNext));

            return Current.Fold(getNext, failure => Failure(failure));
        }

        public Result<TSuccess, TFailure> Next(
            Func<TSuccess, Result<TSuccess, TFailure>> getNext)
        {
            _ = getNext ?? throw new ArgumentNullException(nameof(getNext));

            return Current.Fold(getNext, _ => Current);
        }
    }
}
