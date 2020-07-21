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

            OnPresent(
                value => (value ?? throw exceptionFactory.Invoke()).ToUnit());

            return this;
        }
    }
}
