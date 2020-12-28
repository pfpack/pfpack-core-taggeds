#nullable enable

namespace System
{
    partial class Optional
    {
        public static Optional<T> ToAbsent<T>(T source)
            =>
            source switch
            {
                _ =>
                Optional<T>.Absent
            };

        public static Optional<T> ToAbsent<TSource, T>(TSource source)
            =>
            source switch
            {
                _ =>
                Optional<T>.Absent
            };
    }
}
