#nullable enable

using static System.OptionalExceptionFactories;

namespace System
{
    partial struct Optional<T>
    {
        public Optional<T> NotNullOrThrow() => NotNullOrThrow(CreateNoNotNullValueException);

        public Optional<T> NotNullOrThrow(in Func<Exception> exceptionFactory)
        {
            if (exceptionFactory is null)
            {
                throw new ArgumentNullException(nameof(exceptionFactory));
            }

            return (box is object && box.Value is object) switch
            {
                true => this,
                _ => throw exceptionFactory.Invoke()
            };
        }
    }
}
