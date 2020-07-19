#nullable enable

using static System.OptionalExceptionFactories;

namespace System
{
    partial struct Optional<T>
    {
        public Optional<T> NotNullOrAbsentOrThrow()
            =>
            NotNullOrAbsentOrThrow(CreateNoNotNullOrAbsentValueException);

        public Optional<T> NotNullOrAbsentOrThrow(Func<Exception> exceptionFactory)
        {
            if (exceptionFactory is null)
            {
                throw new ArgumentNullException(nameof(exceptionFactory));
            }

            return Filter(
                value => value switch
                {
                    null => throw exceptionFactory.Invoke(),
                    _ => true
                });
        }
    }
}
