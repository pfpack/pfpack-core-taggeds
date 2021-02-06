#nullable enable

namespace System
{
    partial struct Unit
    {
        public static readonly Unit Value;

        public static Unit Get() => default;

        public static Unit From<TResult>(TResult result)
            =>
            result switch { _ => default };
    }
}
