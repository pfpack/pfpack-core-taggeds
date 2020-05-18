#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Optional
    {
        public static Optional<T> Of<T>(in T value)
            =>
            value;

        public static Optional<T> Present<T>(in T value)
            =>
            value ??
            throw CreateNullValueException(paramName: nameof(value));

        public static Optional<T> Absent<T>()
            =>
            default;

        public static Optional<T> OfNullable<T>(in T? value)
            where T : class
            =>
            value ??
            Optional<T>.Absent;

        public static Optional<T> OfNullable<T>(in T? value)
            where T : struct
            =>
            value ??
            Optional<T>.Absent;

        private static Exception CreateNullValueException(in string paramName)
            =>
            new ArgumentNullException(paramName: paramName, message: "Value must be not null.");
    }
}
