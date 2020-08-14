#nullable enable

namespace System
{
    public static class ToStringExtensions
    {
        public static string ToStringOrEmpty<T>(this T value)
            =>
            value switch { not null => value.ToString().OrEmpty(), _ => string.Empty };
    }
}
