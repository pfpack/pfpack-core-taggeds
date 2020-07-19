#nullable enable

namespace System
{
    internal static class OptionalExceptionFactories
    {
        public static Exception CreateNoValueException()
            =>
            new InvalidOperationException("The optional does not have a value.");

        public static Exception CreateNoNotNullValueException()
            =>
            new InvalidOperationException("The optional does not have a not null value.");

        public static Exception CreateNoNotNullOrAbsentValueException()
            =>
            new InvalidOperationException("The optional does not have a not null or absent value.");
    }
}
