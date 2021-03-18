#nullable enable

namespace System
{
    partial class Optional
    {
        public static Optional<T> PresentOrElse<T>(T? value)
            =>
            value is not null
                ? Optional<T>.Present(value)
                : Optional<T>.Absent;

        public static Optional<T> PresentOrElse<T>(T? value)
            where T : struct
            =>
            value is not null
                ? Optional<T>.Present(value.GetValueOrDefault())
                : Optional<T>.Absent;
    }
}
