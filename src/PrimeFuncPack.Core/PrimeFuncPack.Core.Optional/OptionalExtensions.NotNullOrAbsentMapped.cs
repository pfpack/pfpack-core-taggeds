#nullable enable

namespace System
{
    partial class OptionalExtensions
    {
        public static Optional<T> NotNullOrAbsentMapped<T>(this in Optional<T?> optional) where T : class
            =>
            optional
            .NotNullOrAbsent()
            .Map(value => value ?? throw new ArgumentNullException(nameof(value))); // Just to not to use ! (null-forgiving) operator

        public static Optional<T> NotNullOrAbsentMapped<T>(this in Optional<T?> optional) where T : struct
            =>
            optional
            .NotNullOrAbsent()
            .Map(value => value ?? throw new ArgumentNullException(nameof(value))); // Just to not to use ! (null-forgiving) operator
    }
}
