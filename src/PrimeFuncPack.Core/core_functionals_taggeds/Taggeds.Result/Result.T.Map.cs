#nullable enable

namespace System
{
    partial struct Result<TSuccess, TFailure>
    {
        public Result<TResultSuccess, TFailure> MapSuccess<TResultSuccess>(
            Func<TSuccess, TResultSuccess> mapSuccess)
            where TResultSuccess : notnull
            =>
            MapSuccessSource.MapFirst(mapSuccess).AsResult();

        public Result<TSuccess, TResultFailure> MapFailure<TResultFailure>(
            Func<TFailure, TResultFailure> mapFailure)
            where TResultFailure : notnull, new()
            =>
            MapFailureSource.MapSecond(mapFailure).AsResult();

        public Result<TResultSuccess, TResultFailure> Map<TResultSuccess, TResultFailure>(
            Func<TSuccess, TResultSuccess> mapSuccess,
            Func<TFailure, TResultFailure> mapFailure)
            where TResultSuccess : notnull
            where TResultFailure : notnull, new()
            =>
            MapSource.Map(mapSuccess, mapFailure).AsResult();

        private TaggedUnion<TSuccess, TFailure> MapSuccessSource => union;

        private TaggedUnion<TSuccess, TFailure> MapFailureSource => union.OrFailure();

        private TaggedUnion<TSuccess, TFailure> MapSource => union.OrFailure();
    }
}
