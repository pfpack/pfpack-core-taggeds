#nullable enable

namespace System
{
    public static class ToStringExtensions
    {
        public static string ToStringOrEmpty<T>(this T value)
            =>
            value.ToStringOrEmpty(value => value!.ToString());

        public static string ToStringOrEmpty<T>(this T value, in Func<T, string?> fromNotNull)
        {
            _ = fromNotNull ?? throw new ArgumentNullException(nameof(fromNotNull));

            return value switch { not null => fromNotNull.Invoke(value).OrEmpty(), _ => string.Empty };
        }
    }
}
