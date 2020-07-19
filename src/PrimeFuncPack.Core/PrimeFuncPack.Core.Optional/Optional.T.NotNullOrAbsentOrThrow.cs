#nullable enable

using static System.OptionalExceptionFactories;

namespace System
{
    partial struct Optional<T>
    {
        public Optional<T> NotNullOrAbsentOrThrow() => NotNullOrAbsentOrThrow(CreateNoNotNullOrAbsentValueException);

        public Optional<T> NotNullOrAbsentOrThrow(in Func<Exception> exceptionFactory)
        {
            if (exceptionFactory is null)
            {
                throw new ArgumentNullException(nameof(exceptionFactory));
            }

            return (box is null || box.Value is object) switch
            {
                true => this,
                _ => throw exceptionFactory.Invoke()
            };
        }
    }
}
