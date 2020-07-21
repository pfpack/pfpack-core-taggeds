#nullable enable

using static System.OptionalExceptionFactories;

namespace System
{
    partial struct Optional<T>
    {
        public Optional<T> NotNullOrThrow()
            =>
            NotNullOrThrow(CreateNoNotNullValueException);

        public Optional<T> NotNullOrThrow(Func<Exception> exceptionFactory)
        {
            if (exceptionFactory is null)
            {
                throw new ArgumentNullException(nameof(exceptionFactory));
            }

            OnAbsent(
                () => throw exceptionFactory.Invoke());

            OnPresent(
                value => (value ?? throw exceptionFactory.Invoke()).ToUnit());

            return this;
        }
    }
}
